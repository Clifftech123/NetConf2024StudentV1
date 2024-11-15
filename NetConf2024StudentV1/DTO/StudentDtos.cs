namespace NetConf2024StudentV1.DTO
{

    public class CreateStudentDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }

    public class UpdateStudentDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }



    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }


    public class DeleteStudentDto
    {
        public int Id { get; set; }
    }
}
