using System;

namespace prjC
{
    class Author
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public DateTime BirthDate { get; set; }
        public Author() { }

        public Author(int id, string fn, string ln, string ab)
        {
            this.AuthorID = id;
            this.FirstName = fn;
            this.LastName = ln;
            this.About = ab;
        }
    }
}
