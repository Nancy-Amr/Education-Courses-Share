using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CoursesSharesDB.Services
{
    public class DatabaseMigration
    {
        private const string ConnectionString = "mongodb://localhost:27017";
        private const string DatabaseName = "CoursesSharesDB";
        private const string UsersCollection = "users";

        public static void RunMigration()
        {
            try
            {
                var client = new MongoClient(ConnectionString);
                var database = client.GetDatabase(DatabaseName);
                
                // 1. Update Validation Rules
                UpdateValidationRules(database);

                // 2. Hash Plain Text Passwords
                HashPlainPasswords(database);
            }
            catch (Exception ex)
            {
                // In a real app, you might want to log this or halt startup depending on severity
                // For now, we'll just fail silently or re-throw if it's critical, 
                // but since this is a dev tool convenience, we'll just continue
                System.Diagnostics.Debug.WriteLine($"Migration Error: {ex.Message}");
            }
        }

        private static void UpdateValidationRules(IMongoDatabase database)
        {
            // We need to run the collMod command to update validation
            // This mirrors the update_validation_and_hash_admin.js logic
            var command = new BsonDocument
            {
                { "collMod", UsersCollection },
                { "validator", new BsonDocument
                    {
                        { "$jsonSchema", new BsonDocument
                            {
                                { "bsonType", "object" },
                                { "required", new BsonArray { "_id", "username", "email", "password", "role", "createdAt" } },
                                { "properties", new BsonDocument
                                    {
                                        { "_id", new BsonDocument { { "bsonType", "int" }, { "description", "User ID must be an integer" } } },
                                        { "username", new BsonDocument { { "bsonType", "string" }, { "minLength", 3 }, { "description", "Username must be a string with at least 3 characters" } } },
                                        { "email", new BsonDocument { { "bsonType", "string" }, { "pattern", "^[\\w\\-.]+@([\\w-]+\\.)+[\\w-]{2,}$" }, { "description", "Must be a valid email format" } } },
                                        { "password", new BsonDocument { { "bsonType", "string" }, { "minLength", 44 }, { "description", "Password hash must be a Base64 SHA256 hash" } } },
                                        { "role", new BsonDocument { { "enum", new BsonArray { "student", "instructor", "admin" } }, { "description", "Role must be either 'student', 'instructor', or 'admin'" } } },
                                        { "profilePicture", new BsonDocument { { "bsonType", new BsonArray { "string", "null" } }, { "description", "Profile picture URL or null" } } },
                                        { "createdAt", new BsonDocument { { "bsonType", "date" }, { "description", "Date the account was created" } } }
                                    }
                                }
                            }
                        }
                    }
                },
                { "validationLevel", "moderate" },
                { "validationAction", "warn" }
            };

            try 
            {
                database.RunCommand<BsonDocument>(command);
            } 
            catch (Exception ex) 
            {
                // If the collection doesn't exist yet or other DB issue
                System.Diagnostics.Debug.WriteLine($"Validation Update Warning: {ex.Message}");
            }
        }

        private static void HashPlainPasswords(IMongoDatabase database)
        {
            var collection = database.GetCollection<BsonDocument>(UsersCollection);
            var users = collection.Find(new BsonDocument()).ToList();

            foreach (var user in users)
            {
                if (!user.Contains("password")) continue;

                string currentPassword = user["password"].AsString;

                // Check if already hashed (Base64 SHA256 is 44 chars and usually ends with =)
                if (currentPassword.Length == 44 && currentPassword.EndsWith("="))
                {
                    continue; // Already hashed
                }

                // It's a plain text password, hash it
                string hashedPassword = HashPassword(currentPassword);

                // Update the user
                var filter = Builders<BsonDocument>.Filter.Eq("_id", user["_id"]);
                var update = Builders<BsonDocument>.Update.Set("password", hashedPassword);
                
                collection.UpdateOne(filter, update);
            }
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
