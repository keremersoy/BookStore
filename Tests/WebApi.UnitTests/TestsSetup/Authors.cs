using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {

            context.Authors.AddRange(
                new Author
                {
                    Name = "Eric Ries",
                    Birthday = new DateTime(1978, 09, 22)
                },
                new Author
                {
                    Name = "Charlotte Perkins Gilman",
                    Birthday = new DateTime(1860, 07, 03)
                },
                new Author
                {
                    Name = "Frank Herbert",
                    Birthday = new DateTime(1986, 02, 11)
                });
        }
    }
}