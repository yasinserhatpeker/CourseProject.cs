# CourseProject.cs

## About the Project

CourseProject.cs is a modern course management application developed using C#. The project uses EntityFramework Core as the ORM and SQLite as the database.

## 🚀 Features

- **Course Management**: Add, edit, and delete courses  
- **Student Enrollment System**: Manage student information  
- **Database Integration**: Using SQLite with EntityFramework Core  
- **CRUD Operations**: Full Create, Read, Update, Delete functionality  
- **Modern C# Syntax**: Uses the latest C# features  

## 🛠️ Technologies

- **C#**: Primary programming language  
- **EntityFramework Core**: ORM (Object-Relational Mapping) tool  
- **SQLite**: Lightweight and portable database  
- **.NET Core / .NET 6+**: Framework  

## 📋 Requirements

- .NET 6.0 or higher  
- Visual Studio 2022 or Visual Studio Code  
- EntityFramework Core NuGet packages  

## 🔧 Installation

### 1. Clone the repository
```bash
git clone https://github.com/yasinserhatpeker/CourseProject.cs.git
cd CourseProject.cs
```

### 2. Restore dependencies
```bash
dotnet restore
```

### 3. Create the database
```bash
dotnet ef database update
```

### 4. Run the application
```bash
dotnet run
```

## 📦 Required NuGet Packages

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="7.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="7.0.0" />
```

## 🗄️ Database Structure

### Courses Table
- CourseId (Primary Key)  
- CourseName  
- CourseDescription  
- Credits  
- CreatedDate  

### Students Table
- StudentId (Primary Key)  
- FirstName  
- LastName  
- Email  
- EnrollmentDate  

### Enrollments Table (Relation Table)
- EnrollmentId (Primary Key)  
- StudentId (Foreign Key)  
- CourseId (Foreign Key)  
- EnrollmentDate  

## 💻 Usage Examples

### Adding a New Course
```csharp
var course = new Course
{
    CourseName = "C# Programming",
    CourseDescription = "Basic C# programming course",
    Credits = 3
};

context.Courses.Add(course);
context.SaveChanges();
```

### Saving a Student
```csharp
var student = new Student
{
    FirstName = "John",
    LastName = "Doe",
    Email = "john.doe@email.com"
};

context.Students.Add(student);
context.SaveChanges();
```

## 🏗️ Project Structure

```
CourseProject.cs/
├── Models/
│   ├── Course.cs
│   ├── Student.cs
│   └── Enrollment.cs
├── Data/
│   └── CourseContext.cs
├── Services/
│   ├── CourseService.cs
│   └── StudentService.cs
├── Program.cs
└── README.md
```

## 📝 Migration Commands

### Creating a New Migration
```bash
dotnet ef migrations add MigrationName
```

### Applying Migration
```bash
dotnet ef database update
```

### Reverting Migration
```bash
dotnet ef database update PreviousMigrationName
```

## 🤝 Contributing

1. Fork the repository  
2. Create a new feature branch (`git checkout -b feature/AmazingFeature`)  
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)  
4. Push the branch (`git push origin feature/AmazingFeature`)  
5. Open a Pull Request  

## 📄 License

This project is licensed under the MIT License. See the `LICENSE` file for details.

## 👨‍💻 Developer

**Yasin Serhat Peker**  
- GitHub: [@yasinserhatpeker](https://github.com/yasinserhatpeker)  

## 📞 Contact

If you have any questions about this project, please use GitHub Issues or contact me directly.

## 🔄 Version History

- **v1.0.0** - Initial release  
  - Basic CRUD operations  
  - EntityFramework Core integration  
  - SQLite database support  

---

⭐ **If you like this project, don't forget to give it a star!**
