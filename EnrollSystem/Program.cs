public class Student 
{
    public string name;
    public int id;
    
    public Student (string nameValue, int idValue) 
    {
        name = nameValue;
        id = idValue;
    }

    public string GetName () 
    {
        return name;
    }
}

public class Course 
{
    public string name;
    Student[] participants;
    public int id;
    public Course (string nameValue) 
    {
        name = nameValue;
        participants = new Student[10]; // NOTE: This constant is BAD!
    }
    public void EnrollStudentInCourse (Student student) 
    {
        for (int i=0 ; i<participants.Length ; i++) 
        {
            if (participants[i] == null) 
            {
                participants[i] = student;
                return;
            }
        }
    }
    public void RemoveStudentFromCourse (Student student) 
    {
        for (int i=0 ; i<participants.Length ; i++) 
        {
            if (participants[i] == student) 
            {
                participants[i] = null;
            }
        }
    }
    public Student[] GetParticipants () 
    {
        // count number of entries
        int count = 0;
        foreach (Student student in participants) 
        {
            if (student != null) 
            {
                count++;
            }
        }
        // make a copy
        Student[] result = new Student[count];
        int index = 0;
        foreach (Student student in participants) 
        {
            if (student != null) 
            {
                result[index++] = student;
            }
        }
        return result;
    }
}
    public class EnrollmentSystem
    {
    public Student[] students;
    public Course[] courses;
    
    public void EnrollStudentInCourse(Student student, Course course) 
    {
        course.EnrollStudentInCourse(student);
    }
    
    public void RemoveStudentFromCourse(Student student, Course course) 
    {
        course.RemoveStudentFromCourse(student);
    }

    public void RemoveStudent(Student student)
    {
        for(int index = 0; index < students.Length; index++)    //remove from list
        {
            if (student.id == students[index].id)
            {
                students[index] = null;
            }
        }

        foreach (Course course in courses)                      //remove from all course
        {
            RemoveStudentFromCourse(student, course); 
        }
    }

    public void RemoveCourse(Course course)
    {
        for(int index = 0; index < courses.Length; index++)
        {
            if (course.name == courses[index].name)
            {
                courses[index] = null;
            }
        }
    }
    
    public void ShowParticipants(Course course) 
    {
        foreach (Student student in course.GetParticipants()) 
        {
            Console.WriteLine(student.GetName());
        }
    }

    public void GetCourses() 
    {
        Console.WriteLine("void for a getter?");
    }
    
    public void GetStudents() 
    {
        Console.WriteLine("void for a getter?");
    }
}