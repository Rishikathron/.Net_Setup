using Sample_API.NewFolder;

namespace Sample_API.BusinessLogic
{
    public class BsStudent
    {

        #region "Initializers"
        private readonly DBContext _context;
        public BsStudent(DBContext _context)
        {
            this._context = _context;
        }

        #endregion
        public List<StudentDetails> getUserDetails(int id)
        {
            try
            {
                List<StudentDetails> studentsList = new List<StudentDetails>();
                var records = _context.Students.Where(x => x.StudentId == id).ToList();
                foreach (var student in records)
                {
                    StudentDetails studentDetails = new StudentDetails();
                    studentDetails.Id = id;
                    studentDetails.Email = student.EmailId;
                    studentDetails.PhoneNumber = student.PhoneNumber;
                    studentDetails.StudentName = student.StudentName;
                    studentsList.Add(studentDetails);                    
                }
                return studentsList;
            }
            catch(Exception ex)
            {                
                throw;
            }

        }
    }
}
