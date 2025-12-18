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
            // Validation
            if (string.IsNullOrWhiteSpace(txtTopicName.Text))
            {
                MessageBox.Show("Please enter a topic name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                //  Prepare the list if it's null 
                if (_course.Topics == null)
                {
                    _course.Topics = new List<Topic>();
                }

                //  Generate ID and Create Topic Object
                var newTopicId = _course.Topics.Count > 0 ? _course.Topics.Max(t => t.TopicId) + 1 : 1;
                var newTopic = new Topic
                {
                    TopicId = newTopicId,
                    Name = txtTopicName.Text.Trim(),
                    CourseCode = _course.Code
                };

                //  Update the local object
                _course.Topics.Add(newTopic);

                // Save changes using the Repository
                // useing the existing UpdateCourse method which handles the database logic
                var repository = new Repository();
                bool success = repository.UpdateCourse(_course);

                if (success)
                {
                    TopicsModified = true;
                    LoadTopics();
                    txtTopicName.Clear();
                    MessageBox.Show("Topic added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Revert local change if DB update failed
                    _course.Topics.Remove(newTopic);
                    MessageBox.Show("Failed to save the topic to the database.", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void CourseTopicsForm_Load(object sender, EventArgs e)
        {

        }
    }
}