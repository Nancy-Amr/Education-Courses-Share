using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using CoursesSharesDB.DAL;

namespace CoursesSharesDB.Forms
{
    public partial class ReportsForm : Form
    {
        private MongoDBContext _context;

        public ReportsForm()
        {
            InitializeComponent();
            _context = new MongoDBContext();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dataGridViewReports.AutoGenerateColumns = true;
        }

        private void btnPopularResources_Click(object sender, EventArgs e)
        {
            lblReportDescription.Text = "Most Popular Resources in CSE349 (Sorted by number of saves)";

            // Pipeline 1: Display resources for a course in most popular order (by saves)
            var pipeline = new[]
            {
                BsonDocument.Parse(@"{
                    $group: {
                        _id: '$resource_id',
                        saves: { $sum: 1 }
                    }
                }"),
                BsonDocument.Parse(@"{
                    $lookup: {
                        from: 'resources',
                        localField: '_id',
                        foreignField: '_id',
                        as: 'resource'
                    }
                }"),
                BsonDocument.Parse(@"{ $unwind: '$resource' }"),
                BsonDocument.Parse(@"{
                    $match: {
                        'resource.course_code': 'CSE349'
                    }
                }"),
                BsonDocument.Parse(@"{ $sort: { saves: -1 } }"),
                BsonDocument.Parse(@"{
                    $project: {
                        _id: 0,
                        resource_id: '$_id',
                        name: '$resource.name',
                        course_code: '$resource.course_code',
                        saves: 1
                    }
                }")
            };

            try
            {
                var results = _context.SavedResources.Aggregate<BsonDocument>(pipeline).ToList();
                DisplayResults(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResourceEngagement_Click(object sender, EventArgs e)
        {
            lblReportDescription.Text = "Resource Engagement Analysis (Reactions, Saves, Comments)";

            // Pipeline 2: Resource engagement
            var pipeline = new[]
            {
                BsonDocument.Parse(@"{
                    $addFields: {
                        reaction_count: { $size: '$reactions' }
                    }
                }"),
                BsonDocument.Parse(@"{
                    $lookup: {
                        from: 'saved_resources',
                        localField: '_id',
                        foreignField: 'resource_id',
                        as: 'saved_docs'
                    }
                }"),
                BsonDocument.Parse(@"{
                    $lookup: {
                        from: 'comments',
                        localField: '_id',
                        foreignField: 'resource_id',
                        as: 'comment_docs'
                    }
                }"),
                BsonDocument.Parse(@"{
                    $addFields: {
                        saves_count: { $size: '$saved_docs' },
                        comments_count: { $size: '$comment_docs' }
                    }
                }"),
                BsonDocument.Parse(@"{
                    $project: {
                        _id: 0,
                        resource_id: '$_id',
                        name: 1,
                        course_code: 1,
                        reaction_count: 1,
                        saves_count: 1,
                        comments_count: 1,
                        total_engagement: { 
                            $add: [
                                { $size: '$reactions' },
                                { $size: '$saved_docs' },
                                { $size: '$comment_docs' }
                            ] 
                        }
                    }
                }"),
                BsonDocument.Parse(@"{ $sort: { total_engagement: -1 } }")
            };

            try
            {
                var results = _context.Resources.Aggregate<BsonDocument>(pipeline).ToList();
                DisplayResults(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCourseResourceSummary_Click(object sender, EventArgs e)
        {
            lblReportDescription.Text = "Course Resource Summary (Total resources count per course)";

            // Pipeline 3: Course resource summary for all courses
            var pipeline = new[]
            {
                BsonDocument.Parse(@"{
                    $lookup: {
                        from: 'resource_categories',
                        localField: 'category_id',
                        foreignField: '_id',
                        as: 'category_details'
                    }
                }"),
                BsonDocument.Parse(@"{ $unwind: '$category_details' }"),
                BsonDocument.Parse(@"{
                    $group: {
                        _id: { 
                            course: '$course_code', 
                            type: '$category_details.name' 
                        },
                        count: { $sum: 1 }
                    }
                }"),
                BsonDocument.Parse(@"{
                    $group: {
                        _id: '$_id.course',
                        total_materials: { $sum: '$count' }
                    }
                }"),
                BsonDocument.Parse(@"{
                    $lookup: {
                        from: 'courses',
                        localField: '_id',
                        foreignField: 'code',
                        as: 'course_info'
                    }
                }"),
                BsonDocument.Parse(@"{
                    $unwind: {
                        path: '$course_info',
                        preserveNullAndEmptyArrays: true
                    }
                }"),
                BsonDocument.Parse(@"{ $sort: { total_materials: -1 } }"),
                BsonDocument.Parse(@"{
                    $project: {
                        _id: 0,
                        course_code: '$_id',
                        course_name: { $ifNull: ['$course_info.name', 'Unknown'] },
                        total_materials: 1
                    }
                }")
            };

            try
            {
                var results = _context.Resources.Aggregate<BsonDocument>(pipeline).ToList();
                DisplayResults(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMonthlyUploads_Click(object sender, EventArgs e)
        {
            lblReportDescription.Text = "Monthly Resource Uploads Trend";

            // Pipeline 4: Monthly resource uploads trend
            var pipeline = new[]
            {
                BsonDocument.Parse(@"{
                    $group: {
                        _id: {
                            year: { $year: '$upload_date' },
                            month: { $month: '$upload_date' }
                        },
                        total_uploads: { $sum: 1 }
                    }
                }"),
                BsonDocument.Parse(@"{ 
                    $sort: { 
                        '_id.year': 1, 
                        '_id.month': 1 
                    } 
                }"),
                BsonDocument.Parse(@"{
                    $project: {
                        _id: 0,
                        year: '$_id.year',
                        month: '$_id.month',
                        month_name: {
                            $switch: {
                                branches: [
                                    { case: { $eq: ['$_id.month', 1] }, then: 'January' },
                                    { case: { $eq: ['$_id.month', 2] }, then: 'February' },
                                    { case: { $eq: ['$_id.month', 3] }, then: 'March' },
                                    { case: { $eq: ['$_id.month', 4] }, then: 'April' },
                                    { case: { $eq: ['$_id.month', 5] }, then: 'May' },
                                    { case: { $eq: ['$_id.month', 6] }, then: 'June' },
                                    { case: { $eq: ['$_id.month', 7] }, then: 'July' },
                                    { case: { $eq: ['$_id.month', 8] }, then: 'August' },
                                    { case: { $eq: ['$_id.month', 9] }, then: 'September' },
                                    { case: { $eq: ['$_id.month', 10] }, then: 'October' },
                                    { case: { $eq: ['$_id.month', 11] }, then: 'November' },
                                    { case: { $eq: ['$_id.month', 12] }, then: 'December' }
                                ],
                                default: 'Unknown'
                            }
                        },
                        count: '$total_uploads'
                    }
                }")
            };

            try
            {
                var results = _context.Resources.Aggregate<BsonDocument>(pipeline).ToList();
                DisplayResults(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayResults(List<BsonDocument> documents)
        {
            if (documents.Count == 0)
            {
                dataGridViewReports.DataSource = null;
                MessageBox.Show("No data found for this report.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var dt = new System.Data.DataTable();

                // Create columns based on first document
                foreach (var element in documents[0].Elements)
                {
                    dt.Columns.Add(element.Name);
                }

                // Add rows
                foreach (var doc in documents)
                {
                    var row = dt.NewRow();
                    foreach (var element in doc.Elements)
                    {
                        if (element.Value.IsBsonArray)
                        {
                            // Handle arrays (like resources_summary)
                            var array = element.Value.AsBsonArray;
                            row[element.Name] = array.Count > 0 ? "Array with " + array.Count + " items" : "Empty";
                        }
                        else
                        {
                            row[element.Name] = element.Value.ToString();
                        }
                    }
                    dt.Rows.Add(row);
                }

                dataGridViewReports.DataSource = dt;

                // Distribute columns equally across available width
                dataGridViewReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying results: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ADD THESE MISSING EVENT HANDLERS:

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            // Form load event - can be used for additional initialization
        }
    }
}