// Team 16
// Education - Courses Shares MongoDB Script - Phase 2
// Database
db = db.getSiblingDB("CoursesSharesDB");

// Clear existing database
db.dropDatabase();

// Collections
db.createCollection("users");
db.createCollection("courses");
db.createCollection("resources");
db.createCollection("saved_resources");
db.createCollection("departments");
db.createCollection("comments");
db.createCollection("resource_categories");

// Create indexes for better performance
db.users.createIndex({ username: 1 }, { unique: true });
db.users.createIndex({ email: 1 }, { unique: true });
db.courses.createIndex({ code: 1 }, { unique: true });
db.resources.createIndex({ course_code: 1 });
db.resources.createIndex({ upload_date: -1 });
db.resources.createIndex({ name: "text", description: "text" });
db.saved_resources.createIndex({ user_id: 1, resource_id: 1 });
db.comments.createIndex({ resource_id: 1 });

db.departments.insertMany([
    { _id: 1, name: "Materials Engineering", description: "Materials Engineering Department" },
    { _id: 2, name: "Manufacturing Engineering", description: "Manufacturing Engineering Department" },
    { _id: 3, name: "Mechatronics Engineering and Automation", description: "Mechatronics and Automation Department" },
    { _id: 4, name: "Landscape Architecture", description: "Landscape Architecture Department" },
    { _id: 5, name: "Environmental Architecture and Urbanism", description: "Environmental Architecture and Urbanism Department" },
    { _id: 6, name: "Housing Architecture and Urban Development", description: "Housing Architecture and Urban Development Department" },
    { _id: 7, name: "Communication Systems Engineering", description: "Communication Systems Engineering Department" },
    { _id: 8, name: "Energy and Renewable Energy Engineering", description: "Energy and Renewable Energy Department" },
    { _id: 9, name: "Computer and Artificial Intelligence Engineering", description: "Computer and AI Engineering Department" },
    { _id: 10, name: "Building Engineering", description: "Building Engineering Department" },
    { _id: 11, name: "Civil Infrastructure Engineering", description: "Civil Infrastructure Engineering Department" }
]);

// Users
db.users.insertMany([
    {
        _id: 1,
        username: "malak_mohamed",
        email: "21P0277@eng.asu.edu.eg",
        password: "HASH1",
        role: "student",
        profilePicture: null,
        createdAt: new Date("2025-10-01")
    },
    {
        _id: 2,
        username: "hager_hesham",
        email: "21P0297@eng.asu.edu.eg",
        password: "HASH2",
        role: "student",
        profilePicture: null,
        createdAt: new Date("2025-09-20")
    },
    {
        _id: 3,
        username: "nancy_amro",
        email: "2101421@eng.asu.edu.eg",
        password: "HASH3",
        role: "student",
        profilePicture: null,
        createdAt: new Date("2025-09-22")
    },
    {
        _id: 4,
        username: "mostafa_hassan",
        email: "21P0349@eng.asu.edu.eg",
        password: "HASH4",
        role: "student",
        profilePicture: null,
        createdAt: new Date("2025-09-25")
    },
    {
        _id: 5,
        username: "adel_mohamed",
        email: "21P0113@eng.asu.edu.eg",
        password: "HASH5",
        role: "student",
        profilePicture: null,
        createdAt: new Date("2025-09-28")
    },
    {
        _id: 6,
        username: "nivin_atef",
        email: "e07662@eng.asu.edu.eg",
        password: "HASH6",
        role: "instructor",
        profilePicture: null,
        createdAt: new Date("2025-09-01")
    },
    {
        _id: 7,
        username: "esraa_karam",
        email: "e07881@eng.asu.edu.eg",
        password: "HASH7",
        role: "instructor",
        profilePicture: null,
        createdAt: new Date("2025-09-01")
    },
    {
        _id: 8,
        username: "ayman_bahaa",
        email: "ayman.bahaa@eng.asu.edu.eg",
        password: "HASH8",
        role: "instructor",
        profilePicture: null,
        createdAt: new Date("2025-09-01")
    },
    {
        _id: 9,
        username: "mahmoud_mounir",
        email: "mahmoud.mounir@eng.asu.edu.eg",
        password: "HASH9",
        role: "instructor",
        profilePicture: null,
        createdAt: new Date("2025-09-01")
    },
    {
        _id: 10,
        username: "haytham_azmi",
        email: "haytham.azmi@eng.asu.edu.eg",
        password: "HASH10",
        role: "instructor",
        profilePicture: null,
        createdAt: new Date("2025-09-01")
    },
    {
        _id: 11,
        username: "walaa_khaled",
        email: "walaa.khaled@eng.asu.edu.eg",
        password: "HASH11",
        role: "instructor",
        profilePicture: null,
        createdAt: new Date("2025-09-01")
    },
    {
        _id: 12,
        username: "marwan_sakr",
        email: "marwan.sakr@eng.asu.edu.eg",
        password: "HASH12",
        role: "instructor",
        profilePicture: null,
        createdAt: new Date("2025-09-01")
    },
    {
        _id: 100, // Use a high ID number to avoid conflicts
        username: "admin",
        email: "admin@courseshares.edu",
        password: "admin123",
        role: "admin",
        profilePicture: null,
        createdAt: new Date("2025-01-01")
    },
]);

// Courses with embedded topics
db.courses.insertMany([
    {
        code: "CSE349",
        name: "Advanced Database Systems",
        description: "MongoDB, NoSQL, Aggregation",
        departments: [9],
        instructor_names: ["Dr. Nivin Atef", "Dr. Esraa Karam"],
        topics: [
            { topic_id: 1, name: "Week 1 Lecture: Introduction to Advanced Databases & DBMS Big Picture", course_code: "CSE349" },
            { topic_id: 2, name: "Week 1 Lab: Environment Setup + Intro Hands-On (DB tools / MongoDB basics)", course_code: "CSE349" },
            { topic_id: 3, name: "Week 2 Lecture: Storage Media, Disk Space Management & Buffer Management", course_code: "CSE349" },
            { topic_id: 4, name: "Week 2 Lab: Disk/Buffer Management Practice (pages, buffers, costs)", course_code: "CSE349" },
            { topic_id: 5, name: "Week 3 Lecture: File Organization, Page Layout & Record Layout", course_code: "CSE349" },
            { topic_id: 6, name: "Week 3 Lab: Heap Files, Slotted Pages & Record Handling", course_code: "CSE349" },
            { topic_id: 7, name: "Week 4 Lecture: Indexing with B+ Trees (structure, search, delete)", course_code: "CSE349" },
            { topic_id: 8, name: "Week 4 Lab: B+ Tree Index Operations & Performance", course_code: "CSE349" },
            { topic_id: 9, name: "Week 5 Lecture: Hash-Based Indexing & Hash Tables in DBMS", course_code: "CSE349" },
            { topic_id: 10, name: "Week 5 Lab: Hash Indexing + CRUD/Index Hands-On", course_code: "CSE349" },
            { topic_id: 11, name: "Week 6 Lecture: Query Processing & Operator Execution (joins)", course_code: "CSE349" },
            { topic_id: 12, name: "Week 6 Lab: Join Algorithms Practice (nested loop, sort-merge, hash)", course_code: "CSE349" },
            { topic_id: 13, name: "Week 7 Lecture: External Sorting & Advanced Join Costing", course_code: "CSE349" },
            { topic_id: 14, name: "Week 7 Lab: Sorting/Join Cost Experiments on Real Data", course_code: "CSE349" },
            { topic_id: 15, name: "Week 8/9 Lecture: Query Optimization, Plan Enumeration & Cost Estimation", course_code: "CSE349" },
            { topic_id: 16, name: "Week 8/9 Lab: Query Plan Analysis & Optimization Hands-On", course_code: "CSE349" },
            { topic_id: 17, name: "Week 10 Lecture: Transactions & ACID Properties", course_code: "CSE349" },
            { topic_id: 18, name: "Week 10 Lab: Transaction Execution & Consistency Scenarios", course_code: "CSE349" },
            { topic_id: 19, name: "Week 11 Lecture: Concurrency Control & Recovery Concepts", course_code: "CSE349" },
            { topic_id: 20, name: "Week 11 Lab: Concurrency/Recovery Simulation + Final Hands-On", course_code: "CSE349" },
            { topic_id: 21, name: "Advanced Topics: Distributed Databases, NoSQL & Data Warehousing Overview", course_code: "CSE349" }
        ]
    },
    {
        code: "CSE382",
        name: "Data Mining and Business Intelligence",
        description: "Introduces data mining methods for business intelligence, including exploration, association/correlation analysis, clustering, classification, and social network mining for decision-making.",
        departments: [9],
        instructor_names: ["Dr. Mahmoud Mounir", "Dr. Esraa Karam"],
        topics: [
            { topic_id: 1, name: "Overview of Data Mining", course_code: "CSE382" },
            { topic_id: 2, name: "Data Exploration", course_code: "CSE382" },
            { topic_id: 3, name: "Association Analysis", course_code: "CSE382" },
            { topic_id: 4, name: "Correlation Analysis", course_code: "CSE382" },
            { topic_id: 5, name: "Unsupervised Learning (Cluster Analysis)", course_code: "CSE382" },
            { topic_id: 6, name: "Supervised Learning (Classification)", course_code: "CSE382" },
            { topic_id: 7, name: "Graph-Based Mining and Social Network Analysis", course_code: "CSE382" },
        ]
    },
    {
        code: "CSE451",
        name: "Computer and Network Security",
        description: "Covers foundational security concepts in computer systems and networks, including cryptography, secure protocols, threats, attacks, and defenses, supported by practical labs and assignments.",
        departments: [9],
        instructor_names: ["Dr. Ayman Bahaa", "Eng. Marwan Sakr"],
        topics: [
            { topic_id: 1, name: "Introduction to Computer and Network Security", course_code: "CSE451" },
            { topic_id: 2, name: "Classical Encryption Techniques & Symmetric Ciphers", course_code: "CSE451" },
            { topic_id: 3, name: "Block Ciphers and the Data Encryption Standard (DES)", course_code: "CSE451" },
            { topic_id: 4, name: "Advanced Encryption Standard (AES) and Modern Symmetric Encryption", course_code: "CSE451" },
            { topic_id: 5, name: "Public-Key Cryptography and RSA", course_code: "CSE451" },
            { topic_id: 6, name: "Key Management, Diffie-Hellman & Elliptic Curve Cryptography (ECC)", course_code: "CSE451" },
            { topic_id: 7, name: "Cryptographic Hash Functions & Message Authentication Codes (MAC)", course_code: "CSE451" },
            { topic_id: 8, name: "Digital Signatures & Public Key Infrastructure (PKI)", course_code: "CSE451" },
            { topic_id: 9, name: "User Authentication & Access Control", course_code: "CSE451" },
            { topic_id: 10, name: "Malicious Software, Intruders & Software Vulnerabilities", course_code: "CSE451" },
            { topic_id: 11, name: "Network Attacks and Defenses (Firewalls, IDS/IPS)", course_code: "CSE451" },
            { topic_id: 12, name: "Transport-Layer Security (SSL/TLS) and Secure Email (PGP/S/MIME)", course_code: "CSE451" },
            { topic_id: 13, name: "IP Security (IPsec) and Virtual Private Networks (VPNs)", course_code: "CSE451" },
            { topic_id: 14, name: "Wireless and Mobile Network Security", course_code: "CSE451" },
            { topic_id: 15, name: "Web and Application Security", course_code: "CSE451" }
        ]
    },
    {
        code: "CSE431",
        name: "Mobile Programming",
        description: "Covers cross-platform mobile development with Flutter and Dart, including UI design, navigation, state management, storage, and API-based apps through labs and a final project.",
        departments: [9],
        instructor_names: ["Dr. Haytham Azmi", "Eng. Ahmed Wael"],
        topics: [
            { topic_id: 1, name: "Module 1: Introduction to Mobile Programming & Flutter Setup", course_code: "CSE431" },
            { topic_id: 2, name: "Module 2: Dart Fundamentals and Basic App Structure", course_code: "CSE431" },
            { topic_id: 3, name: "Module 3: Flutter Widgets, Layouts, and UI Building", course_code: "CSE431" },
            { topic_id: 4, name: "Module 4: Navigation, Routes, and Multi-Screen Apps", course_code: "CSE431" },
            { topic_id: 5, name: "Module 5: State Management (setState, Provider/BLoC Intro)", course_code: "CSE431" },
            { topic_id: 6, name: "Module 6: Working with APIs, JSON, and Network Requests", course_code: "CSE431" },
            { topic_id: 7, name: "Module 7: Local Storage & Databases (SharedPreferences, SQLite)", course_code: "CSE431" },
            { topic_id: 8, name: "Module 8: Advanced Flutter Features (Animations, Themes, Responsive UI)", course_code: "CSE431" },
            { topic_id: 9, name: "Module 9: Deployment, Testing, and Final Project Integration", course_code: "CSE431" }
        ]
    },
    {
        code: "CSE336",
        name: "Software Design Patterns",
        description: "Introduces common software design patterns and their classification, with practical labs on choosing and applying the right pattern.",
        departments: [9],
        instructor_names: ["Dr. Walaa Khaled Ibn ElWalid"],
        topics: [
            { topic_id: 1, name: "Creational Patterns: Factory Method (Class Scope)", course_code: "CSE336" },
            { topic_id: 2, name: "Creational Patterns: Builder", course_code: "CSE336" },
            { topic_id: 3, name: "Creational Patterns: Prototype", course_code: "CSE336" },
            { topic_id: 4, name: "Creational Patterns: Singleton", course_code: "CSE336" },
            { topic_id: 5, name: "Structural Patterns: Adapter", course_code: "CSE336" },
            { topic_id: 6, name: "Structural Patterns: Bridge", course_code: "CSE336" },
            { topic_id: 7, name: "Structural Patterns: Composite", course_code: "CSE336" },
            { topic_id: 8, name: "Structural Patterns: Decorator", course_code: "CSE336" },
            { topic_id: 9, name: "Structural Patterns: Facade", course_code: "CSE336" },
            { topic_id: 10, name: "Structural Patterns: Flyweight", course_code: "CSE336" },
            { topic_id: 11, name: "Structural Patterns: Proxy", course_code: "CSE336" },
            { topic_id: 12, name: "Behavioral Patterns: Chain of Responsibility", course_code: "CSE336" },
            { topic_id: 13, name: "Behavioral Patterns: Strategy", course_code: "CSE336" }
        ]
    }
]);

// Resource categories
db.resource_categories.insertMany([
    { _id: 1, name: "Lecture Notes" },
    { _id: 2, name: "Assignments" },
    { _id: 3, name: "Links" },
    { _id: 4, name: "Videos" },
    { _id: 5, name: "Labs" },
    { _id: 6, name: "Tutorials" },
    { _id: 7, name: "Quizzes" },
    { _id: 8, name: "Exams" },
    { _id: 9, name: "Projects" },
    { _id: 10, name: "Reference Books" },
    { _id: 11, name: "Practice Sheets" },
    { _id: 12, name: "Slides" }
]);

// Resources
db.resources.insertMany([
    // ---------------- CSE349 -----------------
    {
        _id: 34901,
        name: "CSE349 ADB Lecture 1 - Intro",
        upload_date: new Date("2025-09-21"),
        description: "Introduction to Advanced Database Systems Design. Course roadmap and motivation.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/648348/mod_resource/content/0/CSE349_ADB_Lecture%201_Intro.pdf",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [1],
        uploader_username: "nivin_atef",
        category_id: 12,
        reactions: ["malak_mohamed", "hager_hesham"]
    },
    {
        _id: 34902,
        name: "CSE349 ADB Lecture 2",
        upload_date: new Date("2025-09-28"),
        description: "Storage media, disk space management, and buffer management in DBMS.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/655387/mod_resource/content/0/CSE349_ADB_Lecture%202.pdf",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [3],
        uploader_username: "nivin_atef",
        category_id: 12,
        reactions: ["nancy_amro"]
    },
    {
        _id: 34903,
        name: "Advanced Database Lab 1",
        upload_date: new Date("2025-09-29"),
        description: "Introduction and MongoDB environment setup.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/655012/mod_resource/content/0/Advanced%20Database_Lab1.pdf",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [4],
        uploader_username: "esraa_karam",
        category_id: 5,
        reactions: ["adel_mohamed"]
    },
    {
        _id: 34904,
        name: "CSE349 ADB Lecture 3",
        upload_date: new Date("2025-10-05"),
        description: "File organization, page layout, and record formats in disk-oriented databases.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/659207/mod_resource/content/0/CSE349_ADB_Lecture%203.pdf",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [5],
        uploader_username: "nivin_atef",
        category_id: 12,
        reactions: ["mostafa_hassan"]
    },
    {
        _id: 34905,
        name: "Advanced Database Lab 2",
        upload_date: new Date("2025-10-06"),
        description: "Mapping from SQL to MongoDB.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/mod/resource/view.php?id=183862",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [6],
        uploader_username: "esraa_karam",
        category_id: 5,
        reactions: ["malak_mohamed"]
    },
    {
        _id: 34906,
        name: "CSE349 ADB Lecture 4",
        upload_date: new Date("2025-10-12"),
        description: "Indexing concepts with focus on B+ Trees and index operations.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/661502/mod_resource/content/0/CSE349_ADB_Lecture%204.pdf",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [7],
        uploader_username: "nivin_atef",
        category_id: 12,
        reactions: ["hager_hesham", "nancy_amro"]
    },
    {
        _id: 34907,
        name: "Advanced Database Lab 3",
        upload_date: new Date("2025-10-13"),
        description: "Introduction to Data Modeling",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/mod/resource/view.php?id=184506",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [8],
        uploader_username: "esraa_karam",
        category_id: 5,
        reactions: ["adel_mohamed", "mostafa_hassan"]
    },
    {
        _id: 34908,
        name: "CSE349 ADB Lecture 5",
        upload_date: new Date("2025-10-19"),
        description: "Hash-based indexing and hashing structures in DBMS.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/663895/mod_resource/content/0/CSE349_ADB_Lecture%206.pdf",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [9],
        uploader_username: "nivin_atef",
        category_id: 12,
        reactions: ["malak_mohamed"]
    },
    {
        _id: 34909,
        name: "Advanced Database Lab 4",
        upload_date: new Date("2025-10-20"),
        description: "CRUD Operations.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/mod/resource/view.php?id=185235",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [10],
        uploader_username: "esraa_karam",
        category_id: 5,
        reactions: ["nancy_amro", "hager_hesham"]
    },
    {
        _id: 34910,
        name: "Assignment 1",
        upload_date: new Date("2025-10-21"),
        description: "Assignment on MongoDB CRUD operations with hands-on tasks.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/mod/assign/view.php?id=184811",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [10],
        uploader_username: "esraa_karam",
        category_id: 2,
        reactions: ["adel_mohamed"]
    },
    {
        _id: 34911,
        name: "CSE349 ADB Lecture 6",
        upload_date: new Date("2025-10-26"),
        description: "Query processing and join algorithms (nested loops, sort-merge, hash join).",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/665275/mod_resource/content/0/CSE349_ADB_Lecture%206.pdf",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [11],
        uploader_username: "nivin_atef",
        category_id: 12,
        reactions: ["mostafa_hassan", "malak_mohamed"]
    },
    {
        _id: 34912,
        name: "Advanced Database Lab 5",
        upload_date: new Date("2025-10-27"),
        description: "Query Predicates & Operations.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/mod/resource/view.php?id=185808",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [12],
        uploader_username: "esraa_karam",
        category_id: 5,
        reactions: ["hager_hesham"]
    },
    {
        _id: 34913,
        name: "CSE349 ADB Lecture 7",
        upload_date: new Date("2025-11-02"),
        description: "External sorting and advanced join costing techniques.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/665752/mod_resource/content/0/CSE349%20ADB_Lecture%207.pdf",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [13],
        uploader_username: "nivin_atef",
        category_id: 12,
        reactions: ["nancy_amro"]
    },
    {
        _id: 34914,
        name: "Advanced Database Lab 6",
        upload_date: new Date("2025-11-03"),
        description: "Aggregation Pipeline.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/mod/resource/view.php?id=186119",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [14],
        uploader_username: "esraa_karam",
        category_id: 5,
        reactions: ["adel_mohamed", "mostafa_hassan"]
    },
    {
        _id: 34915,
        name: "olist dataset",
        upload_date: new Date("2025-11-03"),
        description: "Dataset used in optimization/sorting labs and practice.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/mod/resource/view.php?id=185868",
            fileType: "csv"
        },
        course_code: "CSE349",
        topics: [14, 16],
        uploader_username: "esraa_karam",
        category_id: 11,
        reactions: []
    },
    {
        _id: 34916,
        name: "Practice Sheet 1",
        upload_date: new Date("2025-11-04"),
        description: "Practice questions on joins, sorting, and cost estimation.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/mod/assign/view.php?id=185919",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [13, 15],
        uploader_username: "nivin_atef",
        category_id: 11,
        reactions: ["malak_mohamed"]
    },
    {
        _id: 34917,
        name: "CSE349 ADB Lecture 8",
        upload_date: new Date("2025-11-09"),
        description: "Query optimization: plan space, transformation rules, and cost-based selection.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/666584/mod_resource/content/0/CSE349_ADB_Lecture%208.pdf",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [15],
        uploader_username: "nivin_atef",
        category_id: 12,
        reactions: ["hager_hesham", "nancy_amro"]
    },
    {
        _id: 34918,
        name: "Advanced Database Lab 7",
        upload_date: new Date("2025-11-10"),
        description: "Aggregation Pipeline (Join).",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/mod/resource/view.php?id=186415",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [16],
        uploader_username: "esraa_karam",
        category_id: 5,
        reactions: ["mostafa_hassan"]
    },
    {
        _id: 34919,
        name: "Handson 2",
        upload_date: new Date("2025-11-11"),
        description: "Hands-on assignment on query optimization and cost estimation.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/mod/assign/view.php?id=186416",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [15, 16],
        uploader_username: "esraa_karam",
        category_id: 2,
        reactions: ["adel_mohamed"]
    },
    {
        _id: 34920,
        name: "CSE349 ADB Lecture 9",
        upload_date: new Date("2025-11-16"),
        description: "Transactions and ACID properties with motivation.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/666986/mod_resource/content/0/CSE349_ADB_Lecture%209.pdf",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [17],
        uploader_username: "nivin_atef",
        category_id: 12,
        reactions: ["malak_mohamed"]
    },
    {
        _id: 34921,
        name: "Advanced Database Lab 8",
        upload_date: new Date("2025-11-17"),
        description: "Indexing",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/mod/resource/view.php?id=187378",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [18],
        uploader_username: "esraa_karam",
        category_id: 5,
        reactions: ["hager_hesham", "nancy_amro"]
    },
    {
        _id: 34922,
        name: "Assignment 2",
        upload_date: new Date("2025-11-23"),
        description: "MongoDB Assignment — Collections, Indexing, Aggregation.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/mod/assign/view.php?id=187520",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [19, 20],
        uploader_username: "esraa_karam",
        category_id: 2,
        reactions: ["mostafa_hassan"]
    },
    {
        _id: 34923,
        name: "Phase 2 Submission Instructions",
        upload_date: new Date("2025-11-24"),
        description: "Submission guidelines for Phase 2 of the team project.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/mod/assign/view.php?id=186863",
            fileType: "pdf"
        },
        course_code: "CSE349",
        topics: [21],
        uploader_username: "esraa_karam",
        category_id: 2,
        reactions: ["malak_mohamed", "adel_mohamed"]
    },

    // -------------------- CSE451 -------------------------
    {
        _id: 45101,
        name: "CSE451 - Stallings PPT 01 (Introduction)",
        upload_date: new Date("2025-09-22"),
        description: "Course introduction: security goals, threats, services, and basic concepts.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/652901/mod_resource/content/0/Stallings_8e_Accessible_fullppt_01.pdf",
            fileType: "pdf"
        },
        course_code: "CSE451",
        topics: [1],
        uploader_username: "ayman_bahaa",
        category_id: 12,
        reactions: ["malak_mohamed", "hager_hesham"]
    },
    {
        _id: 45102,
        name: "CSE451 - Stallings PPT 02 (Classical Encryption & Symmetric Ciphers)",
        upload_date: new Date("2025-09-29"),
        description: "Classical encryption techniques and symmetric-key cryptography basics.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/652902/mod_resource/content/0/Stallings_8e_Accessible_fullppt_02.pdf",
            fileType: "pdf"
        },
        course_code: "CSE451",
        topics: [2],
        uploader_username: "ayman_bahaa",
        category_id: 12,
        reactions: ["nancy_amro"]
    },
    {
        _id: 45103,
        name: "CSE451 - Stallings PPT 03 (Block Ciphers & DES)",
        upload_date: new Date("2025-10-06"),
        description: "Block cipher principles and the Data Encryption Standard (DES).",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/652903/mod_resource/content/0/Stallings_8e_Accessible_fullppt_03.pdf",
            fileType: "pdf"
        },
        course_code: "CSE451",
        topics: [3],
        uploader_username: "ayman_bahaa",
        category_id: 12,
        reactions: ["mostafa_hassan", "adel_mohamed"]
    },
    {
        _id: 45104,
        name: "CSE451 - Stallings PPT 04 (AES & Modern Symmetric Encryption)",
        upload_date: new Date("2025-10-13"),
        description: "Advanced Encryption Standard (AES), modes of operation, and modern symmetric crypto.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/652904/mod_resource/content/0/Stallings_8e_Accessible_fullppt_04.pdf",
            fileType: "pdf"
        },
        course_code: "CSE451",
        topics: [4],
        uploader_username: "ayman_bahaa",
        category_id: 12,
        reactions: ["malak_mohamed"]
    },
    {
        _id: 45105,
        name: "CSE451 - Stallings PPT 05 (Public-Key Cryptography & RSA)",
        upload_date: new Date("2025-10-20"),
        description: "Public-key cryptography foundations and RSA algorithm.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/652905/mod_resource/content/0/Stallings_8e_Accessible_fullppt_05.pdf",
            fileType: "pdf"
        },
        course_code: "CSE451",
        topics: [5],
        uploader_username: "ayman_bahaa",
        category_id: 12,
        reactions: ["hager_hesham", "adel_mohamed", "nancy_amro"]
    },
    {
        _id: 45106,
        name: "CSE451 - Stallings PPT 06 (Key Management, DH & ECC)",
        upload_date: new Date("2025-10-27"),
        description: "Key exchange, Diffie–Hellman, and Elliptic Curve Cryptography (ECC).",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/652906/mod_resource/content/0/Stallings_8e_Accessible_fullppt_06.pdf",
            fileType: "pdf"
        },
        course_code: "CSE451",
        topics: [6],
        uploader_username: "ayman_bahaa",
        category_id: 12,
        reactions: ["mostafa_hassan"]
    },
    {
        _id: 45107,
        name: "CSE451 - Stallings PPT 07 (Hash Functions & MAC)",
        upload_date: new Date("2025-11-03"),
        description: "Cryptographic hash functions, message authentication codes (MAC), and integrity.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/652907/mod_resource/content/0/Stallings_8e_Accessible_fullppt_07.pdf",
            fileType: "pdf"
        },
        course_code: "CSE451",
        topics: [7],
        uploader_username: "ayman_bahaa",
        category_id: 12,
        reactions: ["nancy_amro", "malak_mohamed"]
    },
    {
        _id: 45108,
        name: "CSE451 - Stallings PPT 08 (Digital Signatures & PKI)",
        upload_date: new Date("2025-11-10"),
        description: "Digital signatures, certificates, and Public Key Infrastructure (PKI).",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/652908/mod_resource/content/0/Stallings_8e_Accessible_fullppt_08.pdf",
            fileType: "pdf"
        },
        course_code: "CSE451",
        topics: [8],
        uploader_username: "ayman_bahaa",
        category_id: 12,
        reactions: ["adel_mohamed"]
    },
    {
        _id: 45109,
        name: "CSE451 - Stallings PPT 09 (Authentication & Access Control)",
        upload_date: new Date("2025-11-17"),
        description: "User authentication models and access control mechanisms.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/mod/resource/view.php?id=181786",
            fileType: "pdf"
        },
        course_code: "CSE451",
        topics: [9],
        uploader_username: "ayman_bahaa",
        category_id: 12,
        reactions: ["hager_hesham", "mostafa_hassan", "malak_mohamed"]
    },
    {
        _id: 45110,
        name: "CSE451 - Stallings PPT 10 (Malware & Software Vulnerabilities)",
        upload_date: new Date("2025-11-24"),
        description: "Malware, intruders, and common software vulnerabilities.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/652910/mod_resource/content/0/Stallings_8e_Accessible_fullppt_10.pdf",
            fileType: "pdf"
        },
        course_code: "CSE451",
        topics: [10],
        uploader_username: "ayman_bahaa",
        category_id: 12,
        reactions: ["nancy_amro"]
    },
    {
        _id: 45111,
        name: "CSE451 - Stallings PPT 11 (Firewalls & IDS/IPS)",
        upload_date: new Date("2025-12-01"),
        description: "Network attacks and defenses including firewalls, IDS, and IPS.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/652911/mod_resource/content/0/Stallings_8e_Accessible_fullppt_11.pdf",
            fileType: "pdf"
        },
        course_code: "CSE451",
        topics: [11],
        uploader_username: "ayman_bahaa",
        category_id: 12,
        reactions: ["mostafa_hassan", "adel_mohamed"]
    },
    {
        _id: 45112,
        name: "CSE451 - Stallings PPT 15 (Secure Protocols & Applications)",
        upload_date: new Date("2025-12-08"),
        description: "Secure protocols and application-level security topics.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/652912/mod_resource/content/0/Stallings_8e_Accessible_fullppt_15.pdf",
            fileType: "pdf"
        },
        course_code: "CSE451",
        topics: [12, 13, 14, 15],
        uploader_username: "ayman_bahaa",
        category_id: 12,
        reactions: ["malak_mohamed", "nancy_amro"]
    },

    // -------------------- CSE382------------------
    {
        _id: 38201,
        name: "CSE382 - Lecture 01 (Overview of Data Mining)",
        upload_date: new Date("2025-09-22"),
        description: "Introduction to data mining, KDD process, tasks, and BI motivation.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/632608/mod_resource/content/0/CSE%20382%20-%20Data%20Mining%20and%20Business%20Intelligence%20-%20Lecture%2001.pdf",
            fileType: "pdf"
        },
        course_code: "CSE382",
        topics: [1],
        uploader_username: "mahmoud_mounir",
        category_id: 12,
        reactions: ["malak_mohamed", "adel_mohamed"]
    },
    {
        _id: 38202,
        name: "CSE382 - Lecture 02 (Association Analysis)",
        upload_date: new Date("2025-09-29"),
        description: "Frequent itemsets and association rule mining.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/632609/mod_resource/content/0/CSE%20382%20-%20Data%20Mining%20and%20Business%20Intelligence%20-%20Lecture%2002.pdf",
            fileType: "pdf"
        },
        course_code: "CSE382",
        topics: [3],
        uploader_username: "mahmoud_mounir",
        category_id: 12,
        reactions: ["hager_hesham"]
    },
    {
        _id: 38203,
        name: "CSE382 - Lecture 04 (Data Exploration)",
        upload_date: new Date("2025-10-06"),
        description: "Exploratory data analysis and preprocessing.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/632612/mod_resource/content/0/CSE%20382%20-%20Data%20Mining%20and%20Business%20Intelligence%20-%20Lecture%2004.pdf",
            fileType: "pdf"
        },
        course_code: "CSE382",
        topics: [2],
        uploader_username: "mahmoud_mounir",
        category_id: 12,
        reactions: ["nancy_amro", "mostafa_hassan"]
    },
    {
        _id: 38204,
        name: "CSE382 - Lecture 05 (Correlation Analysis)",
        upload_date: new Date("2025-10-13"),
        description: "Correlation measures and dependency analysis.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/632613/mod_resource/content/0/CSE%20382%20-%20Data%20Mining%20and%20Business%20Intelligence%20-%20Lecture%2005.pdf",
            fileType: "pdf"
        },
        course_code: "CSE382",
        topics: [4],
        uploader_username: "mahmoud_mounir",
        category_id: 12,
        reactions: ["adel_mohamed"]
    },
    {
        _id: 38205,
        name: "CSE382 - Lecture 06 (Unsupervised Learning - Clustering)",
        upload_date: new Date("2025-10-20"),
        description: "Clustering techniques and evaluation.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/632614/mod_resource/content/0/CSE%20382%20-%20Data%20Mining%20and%20Business%20Intelligence%20-%20Lecture%2006.pdf",
            fileType: "pdf"
        },
        course_code: "CSE382",
        topics: [5],
        uploader_username: "mahmoud_mounir",
        category_id: 12,
        reactions: ["malak_mohamed", "hager_hesham", "mostafa_hassan"]
    },
    {
        _id: 38206,
        name: "CSE382 - Lecture 08 (Graph-Based Mining & Social Network Analysis)",
        upload_date: new Date("2025-10-27"),
        description: "Graph mining and social network analysis.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/632616/mod_resource/content/0/CSE%20382%20-%20Data%20Mining%20and%20Business%20Intelligence%20-%20Lecture%2008.pdf",
            fileType: "pdf"
        },
        course_code: "CSE382",
        topics: [7],
        uploader_username: "mahmoud_mounir",
        category_id: 12,
        reactions: ["nancy_amro"]
    },
    {
        _id: 38207,
        name: "CSE382 - Lecture 10 Part 1 (Supervised Learning - Classification)",
        upload_date: new Date("2025-11-03"),
        description: "Classification models and evaluation metrics.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/632619/mod_resource/content/0/CSE%20382%20-%20Data%20Mining%20and%20Business%20Intelligence%20-%20Lecture%2010%20-%20Part%201.pdf",
            fileType: "pdf"
        },
        course_code: "CSE382",
        topics: [6],
        uploader_username: "mahmoud_mounir",
        category_id: 12,
        reactions: ["adel_mohamed", "mostafa_hassan"]
    },

    // --------------------- CSE431 --------------------
    {
        _id: 43101,
        name: "CSE431 - Module 1 (Introduction & Flutter Setup)",
        upload_date: new Date("2025-09-22"),
        description: "Module 1 slides covering mobile programming basics and Flutter setup.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/646592/mod_resource/content/3/01-Module%201%20-%20updated.pdf",
            fileType: "pdf"
        },
        course_code: "CSE431",
        topics: [1],
        uploader_username: "haytham_azmi",
        category_id: 12,
        reactions: ["malak_mohamed", "nancy_amro"]
    },

    // ---------------------- CSE336 -------------------------
    {
        _id: 33601,
        name: "CSE336 - Lecture 6 (Facade Pattern)",
        upload_date: new Date("2025-10-20"),
        description: "Lecture slides explaining the Facade structural pattern with UML and examples.",
        content: {
            type: "file",
            url: "https://lms.eng.asu.edu.eg/pluginfile.php/663768/mod_resource/content/0/Lecture6.pdf",
            fileType: "pdf"
        },
        course_code: "CSE336",
        topics: [9],
        uploader_username: "walaa_khaled",
        category_id: 12,
        reactions: ["adel_mohamed", "hager_hesham"]
    }
]);

// SAVED_RESOURCES
db.saved_resources.insertMany([
    // malak_mohamed (user_id: 1)
    { user_id: 1, resource_id: 45101, saving_date: new Date("2025-10-01") },
    { user_id: 1, resource_id: 38201, saving_date: new Date("2025-10-08") },
    { user_id: 1, resource_id: 43101, saving_date: new Date("2025-10-15") },

    // hager_hesham (user_id: 2)
    { user_id: 2, resource_id: 34901, saving_date: new Date("2025-10-02") },
    { user_id: 2, resource_id: 45104, saving_date: new Date("2025-10-20") },

    // nancy_amro (user_id: 3)
    { user_id: 3, resource_id: 38205, saving_date: new Date("2025-10-25") },
    { user_id: 3, resource_id: 33601, saving_date: new Date("2025-11-05") },

    // mostafa_hassan (user_id: 4)
    { user_id: 4, resource_id: 34906, saving_date: new Date("2025-10-14") },
    { user_id: 4, resource_id: 45107, saving_date: new Date("2025-11-12") },

    // adel_mohamed (user_id: 5)
    { user_id: 5, resource_id: 38201, saving_date: new Date("2025-10-09") }
]);

// COMMENTS
db.comments.insertMany([
    {
        _id: 1,
        resource_id: 45101,
        user_id: 2,
        text: "Very clear intro, especially the security goals part.",
        time_stamp: new Date("2025-10-02")
    },
    {
        _id: 2,
        resource_id: 38201,
        user_id: 1,
        text: "Good overview of KDD steps. The examples helped a lot.",
        time_stamp: new Date("2025-10-09")
    },
    {
        _id: 3,
        resource_id: 34901,
        user_id: 3,
        text: "Excited for the course after going through these slides!",
        time_stamp: new Date("2025-10-03")
    },
    {
        _id: 4,
        resource_id: 34906,
        user_id: 4,
        text: "Lecture was useful, but the B+Tree steps need one more example.",
        time_stamp: new Date("2025-10-15")
    },
    {
        _id: 5,
        resource_id: 45104,
        user_id: 5,
        text: "AES modes explanation was great. CBC vs CTR finally makes sense.",
        time_stamp: new Date("2025-10-21")
    },
    {
        _id: 6,
        resource_id: 38205,
        user_id: 2,
        text: "Can you upload a small dataset to practice K-means on?",
        time_stamp: new Date("2025-10-26")
    },
    {
        _id: 7,
        resource_id: 45107,
        user_id: 1,
        text: "Hash functions section is perfect, especially SHA and MAC part.",
        time_stamp: new Date("2025-11-06")
    },
    {
        _id: 8,
        resource_id: 43101,
        user_id: 3,
        text: "Flutter setup steps were smooth. Thanks for the clear screenshots.",
        time_stamp: new Date("2025-09-25")
    },
    {
        _id: 9,
        resource_id: 33601,
        user_id: 5,
        text: "Facade pattern example is really helpful. Simple and direct.",
        time_stamp: new Date("2025-10-23")
    },
    {
        _id: 10,
        resource_id: 34911,
        user_id: 4,
        text: "Join algorithms comparison table is very useful.",
        time_stamp: new Date("2025-10-28")
    }
]);

//--------------------------CRUD OPERATIONS ---------------------------

// -------------------- (C) CREATE --------------------

// 1) Insert a new resource (extra CSE382  slide)
db.resources.insertOne({
    _id: 38208,
    name: "CSE382 - Lecture 11 (DBScan Algorithm)",
    upload_date: new Date("2025-11-10"),
    description: "Explain Density-based Clustering (DBScan) with examples.",
    content: {
        type: "file",
        url: "https://lms.eng.asu.edu.eg/pluginfile.php/632621/mod_resource/content/0/CSE%20382%20-%20Data%20Mining%20and%20Business%20Intelligence%20-%20Lecture%2011%20-%20Part%202.pdf",
        fileType: "pdf"
    },
    course_code: "CSE382",
    topics: [6],
    uploader_username: "mahmoud_mounir",
    category_id: 12,
    reactions: ["malak_mohamed"]
});

// 2) Insert a new saved resource (adel_mohamed saves a security slide)
db.saved_resources.insertOne({
    user_id: 5,
    resource_id: 45103,
    saving_date: new Date("2025-11-01")
});

// 3) Insert a new comment (nancy_amro comments on DB lecture 8)
db.comments.insertOne({
    _id: 11,
    resource_id: 34917,
    user_id: 3,
    text: "Optimization lecture is a bit heavy, but the examples were great.",
    time_stamp: new Date("2025-11-10")
});

// -------------------- (R) READ --------------------

print("=== All resources for CSE451 ===");
db.resources.find(
    { course_code: "CSE451" },
    { name: 1, upload_date: 1, topics: 1, uploader_username: 1 }
).sort({ upload_date: 1 }).forEach(printjson);

print("\n=== All resources uploaded by esraa_karam ===");
db.resources.find(
    { uploader_username: "esraa_karam" },
    { _id: 1, name: 1, course_code: 1 }
).forEach(printjson);

print("\n=== All saved resources for malak_mohamed (user_id: 1) ===");
db.saved_resources.find({ user_id: 1 }).forEach(printjson);

print("\n=== All comments for resource 45101 ===");
db.comments.find({ resource_id: 45101 }).sort({ time_stamp: -1 }).forEach(printjson);

print("\n=== Resources for topic 10 in CSE349 ===");
db.resources.find({
    course_code: "CSE349",
    topics: 10
}).forEach(printjson);

// -------------------- (U) UPDATE --------------------

// 1) Add a reaction by mostafa_hassan to a resource (PPT04)
db.resources.updateOne(
    { _id: 45104 },
    { $addToSet: { reactions: "mostafa_hassan" } }
);

// 2) Update resource description (fix wording)
db.resources.updateOne(
    { _id: 34911 },
    { $set: { description: "Query processing and join algorithms with detailed cost analysis." } }
);

// 3) Change a saved_resource date (malak_mohamed re-saves PPT01 later)
db.saved_resources.updateOne(
    { user_id: 1, resource_id: 45101 },
    { $set: { saving_date: new Date("2025-11-20") } }
);

// 4) Edit a comment text
db.comments.updateOne(
    { _id: 4 },
    { $set: { text: "Lab was useful, but B+Tree delete example needs clarification." } }
);

// -------------------- (D) DELETE --------------------

// 1) Remove a reaction from a resource
db.resources.updateOne(
    { _id: 38205 },
    { $pull: { reactions: "hager_hesham" } }
);

// 2) Delete one saved_resource record (nancy_amro unsaves clustering lec)
db.saved_resources.deleteOne({
    user_id: 3,
    resource_id: 38205
});

// 3) Delete a comment by id
db.comments.deleteOne({ _id: 6 });

// 4) Delete a resource completely (if uploaded by mistake)
db.resources.deleteOne({ _id: 38208 });

// ---------------------------- PIPELINES ----------------------------

print("\n=== Most popular resources for CSE349 (by saves) ===");
db.saved_resources.aggregate([
    {
        $group: {
            _id: "$resource_id",
            saves: { $sum: 1 }
        }
    },
    {
        $lookup: {
            from: "resources",
            localField: "_id",
            foreignField: "_id",
            as: "resource"
        }
    },
    { $unwind: "$resource" },
    {
        $match: {
            "resource.course_code": "CSE349"
        }
    },
    { $sort: { saves: -1 } },
    {
        $project: {
            _id: 0,
            resource_id: "$_id",
            name: "$resource.name",
            course_code: "$resource.course_code",
            saves: 1
        }
    }
]).forEach(printjson);

print("\n=== Resource engagement metrics ===");
db.resources.aggregate([
    {
        $addFields: {
            reaction_count: { $size: "$reactions" }
        }
    },
    {
        $lookup: {
            from: "saved_resources",
            localField: "_id",
            foreignField: "resource_id",
            as: "saved_docs"
        }
    },
    {
        $lookup: {
            from: "comments",
            localField: "_id",
            foreignField: "resource_id",
            as: "comment_docs"
        }
    },
    {
        $addFields: {
            saves_count: { $size: "$saved_docs" },
            comments_count: { $size: "$comment_docs" },
        }
    },
    {
        $project: {
            _id: 0,
            resource_id: "$_id",
            name: 1,
            course_code: 1,
            reaction_count: 1,
            saves_count: 1,
            comments_count: 1
        }
    }
]).forEach(printjson);

print("\n=== Course resource summary ===");
db.resources.aggregate([
    {
        $lookup: {
            from: "resource_categories",
            localField: "category_id",
            foreignField: "_id",
            as: "category_details"
        }
    },
    {
        $unwind: "$category_details"
    },
    {
        $group: {
            _id: {
                course: "$course_code",
                type: "$category_details.name"
            },
            count: { $sum: 1 }
        }
    },
    {
        $group: {
            _id: "$_id.course",
            resources_summary: {
                $push: {
                    type: "$_id.type",
                    quantity: "$count"
                }
            },
            total_materials: { $sum: "$count" }
        }
    },
    {
        $sort: { _id: 1 }
    },
    {
        $project: {
            _id: 0,
            course_code: "$_id",
            resources_summary: 1,
            total_materials: 1
        }
    }
]).forEach(printjson);

print("\n=== Monthly resource uploads trend ===");
db.resources.aggregate([
    {
        $group: {
            _id: {
                year: { $year: "$upload_date" },
                month: { $month: "$upload_date" }
            },
            total_uploads: { $sum: 1 }
        }
    },
    {
        $sort: { "_id.year": -1, "_id.month": -1 }
    },
    {
        $project: {
            _id: 0,
            year: "$_id.year",
            month: "$_id.month",
            count: "$total_uploads"
        }
    }
]).forEach(printjson);

// ---------------------------- JSON Schema Validation ----------------------------
db.runCommand({
    collMod: "users",
    validator: {
        $jsonSchema: {
            bsonType: "object",
            required: ["_id", "username", "email", "password", "role", "createdAt"],
            properties: {
                _id: {
                    bsonType: "int",
                    description: "User ID must be an integer"
                },
                username: {
                    bsonType: "string",
                    minLength: 3,
                    description: "Username must be a string with at least 3 characters"
                },
                email: {
                    bsonType: "string",
                    pattern: "^[\\w\\-.]+@([\\w-]+\\.)+[\\w-]{2,}$",
                    description: "Must be a valid email format"
                },
                password: {
                    bsonType: "string",
                    minLength: 8,
                    description: "Password hash must be a string with at least 8 characters"
                },
                role: {
                    enum: ["student", "instructor"],
                    description: "Role must be either 'student' or 'instructor'"
                },
                profilePicture: {
                    bsonType: ["string", "null"],
                    description: "Profile picture URL or null"
                },
                createdAt: {
                    bsonType: "date",
                    description: "Date the account was created"
                }
            }
        }
    },
    validationLevel: "strict",
    validationAction: "error"
});

print("\n=== Database setup completed successfully! ===");
