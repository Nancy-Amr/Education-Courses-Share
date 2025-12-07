using CoursesSharesDB.DAL;
using CoursesSharesDB.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static CoursesSharesDB.Models.Course;

namespace CoursesSharesDB.Forms
{
    public partial class CourseTopicsForm : Form
    {
        private Course _course;
        private MongoDBContext _context;
        public bool TopicsModified { get; private set; }

        public CourseTopicsForm(Course course)
        {
            InitializeComponent();
            _course = course;
            _context = new MongoDBContext();
            TopicsModified = false;
            LoadTopics();
        }

        private void LoadTopics()
        {
            try
            {
                lblCourseInfo.Text = $"{_course.Code} - {_course.Name}";

                if (_course.Topics != null)
                {
                    dataGridViewTopics.DataSource = new List<Topic>(_course.Topics);
                }
                else
                {
                    dataGridViewTopics.DataSource = new List<Topic>();
                }

                lblTopicCount.Text = $"Total Topics: {_course.Topics?.Count ?? 0}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading topics: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTopic_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTopicName.Text))
            {
                MessageBox.Show("Please enter a topic name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newTopicId = _course.Topics?.Count > 0 ? _course.Topics.Max(t => t.TopicId) + 1 : 1;
                var newTopic = new Topic
                {
                    TopicId = newTopicId,
                    Name = txtTopicName.Text.Trim(),
                    CourseCode = _course.Code
                };

                _course.Topics.Add(newTopic);

                // Update in database
                var filter = Builders<Course>.Filter.Eq(c => c.Code, _course.Code);
                var update = Builders<Course>.Update.Set(c => c.Topics, _course.Topics);
                _context.Courses.UpdateOne(filter, update);

                TopicsModified = true;
                LoadTopics();
                txtTopicName.Clear();
                MessageBox.Show("Topic added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding topic: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteTopic_Click(object sender, EventArgs e)
        {
            if (dataGridViewTopics.CurrentRow == null)
            {
                MessageBox.Show("Please select a topic to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedTopic = (Topic)dataGridViewTopics.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Delete topic '{selectedTopic.Name}'?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _course.Topics.RemoveAll(t => t.TopicId == selectedTopic.TopicId);

                    // Update in database
                    var filter = Builders<Course>.Filter.Eq(c => c.Code, _course.Code);
                    var update = Builders<Course>.Update.Set(c => c.Topics, _course.Topics);
                    _context.Courses.UpdateOne(filter, update);

                    TopicsModified = true;
                    LoadTopics();
                    MessageBox.Show("Topic deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting topic: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}