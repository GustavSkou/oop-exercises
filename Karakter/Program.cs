public class DumpetException : Exception 
{
    public DumpetException(string message) : base(message)
    {}

}

class AvgGradeError{

    public int[] grades;
    
    public AvgGradeError(int[] someGrades) {
        grades = someGrades;
    }

    public int GetGrade(int courseId) {
        
        int grade = grades[courseId];
        
        if (grade < 02) {
            throw new DumpetException($"Index {courseId} er dumpet");
        }
    
        return grade;
    }
}

class Program {
    static void Main () {
        int[] grades = {4, 7, 02, 00, 10, 4, 12};
        double sum = 0, count = 0;
        AvgGradeError algotihm = new AvgGradeError(grades);

        for (int i = 0; i < grades.Length; i++) {
            try {
                sum = sum + algotihm.GetGrade(i);
                count++;
            }
            catch (DumpetException e) {
                Console.WriteLine(e.Message);
            }   
        }
        Console.WriteLine(sum/count);
    }
}