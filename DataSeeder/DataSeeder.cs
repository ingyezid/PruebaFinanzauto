using PruebaFinanzauto.DataContext;
using PruebaFinanzauto.Models;

namespace PruebaFinanzauto.DataSeeder
{
    public static class DataSeeder
    {
        public static void Seed(ProjectContext context)
        {

            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new Student { Id = Guid.Parse("c8c5dab5-28e5-4d07-b450-3590f738391a"), Identification = "1234567890" , FirstName = "Juan", LastName = "Pedregales" },
                    new Student { Id = Guid.Parse("c8c5dab5-28e5-4d07-b450-3590f738392b"), Identification = "6789012345", FirstName = "Pablo", LastName = "Garcia" },
                    new Student { Id = Guid.Parse("c8c5dab5-28e5-4d07-b450-3590f738393c"), Identification = "3456789012", FirstName = "Maria", LastName = "Villamil" }
                );
            }

            if (!context.Teachers.Any())
            {
                context.Teachers.AddRange(
                    new Teacher { Id = Guid.Parse("ff5518ec-916f-4045-9cf5-91bf5f7bd44d"), Identification = "1122334455", FirstName = "Sara", LastName = "Guzman" },
                    new Teacher { Id = Guid.Parse("ff5518ec-916f-4045-9cf5-91bf5f7bd45e"), Identification = "6677889900", FirstName = "Jorge", LastName = "Avello" },
                    new Teacher { Id = Guid.Parse("ff5518ec-916f-4045-9cf5-91bf5f7bd46f"), Identification = "2233667744", FirstName = "Milena", LastName = "Rosales" }
                );
            }


            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course { Id = Guid.Parse("5315ce25-23bf-47e5-b127-0f7fb7194177"), TeacherId = Guid.Parse("ff5518ec-916f-4045-9cf5-91bf5f7bd44d"), Name = "Matematicas", Credits = 4 , Description = string.Empty  },
                    new Course { Id = Guid.Parse("5315ce25-23bf-47e5-b127-0f7fb7194188"), TeacherId = Guid.Parse("ff5518ec-916f-4045-9cf5-91bf5f7bd45e"), Name = "Ciencias Naturales" , Credits = 5 , Description = string.Empty },
                    new Course { Id = Guid.Parse("5315ce25-23bf-47e5-b127-0f7fb7194199"), TeacherId = Guid.Parse("ff5518ec-916f-4045-9cf5-91bf5f7bd46f"), Name = "Historia" , Credits = 3 , Description = string.Empty }

                );
            }


            if (!context.Grades.Any())
            {
                context.Grades.AddRange(
                    new Grade { Id = Guid.Parse("a6286eee-9230-4d23-b405-1483204b9350"), CourseId = Guid.Parse("5315ce25-23bf-47e5-b127-0f7fb7194177"), StudentId = Guid.Parse("c8c5dab5-28e5-4d07-b450-3590f738391a"), Score = new decimal(7.5) },
                    new Grade { Id = Guid.Parse("a6286eee-9230-4d23-b405-1483204b9351"), CourseId = Guid.Parse("5315ce25-23bf-47e5-b127-0f7fb7194177"), StudentId = Guid.Parse("c8c5dab5-28e5-4d07-b450-3590f738392b"), Score = new decimal(9.0) },
                    new Grade { Id = Guid.Parse("a6286eee-9230-4d23-b405-1483204b9352"), CourseId = Guid.Parse("5315ce25-23bf-47e5-b127-0f7fb7194177"), StudentId = Guid.Parse("c8c5dab5-28e5-4d07-b450-3590f738393c"), Score = new decimal(8.3) },
                    new Grade { Id = Guid.Parse("a6286eee-9230-4d23-b405-1483204b9353"), CourseId = Guid.Parse("5315ce25-23bf-47e5-b127-0f7fb7194188"), StudentId = Guid.Parse("c8c5dab5-28e5-4d07-b450-3590f738391a"), Score = new decimal(6.6) },
                    new Grade { Id = Guid.Parse("a6286eee-9230-4d23-b405-1483204b9354"), CourseId = Guid.Parse("5315ce25-23bf-47e5-b127-0f7fb7194188"), StudentId = Guid.Parse("c8c5dab5-28e5-4d07-b450-3590f738392b"), Score = new decimal(7.0) },
                    new Grade { Id = Guid.Parse("a6286eee-9230-4d23-b405-1483204b9355"), CourseId = Guid.Parse("5315ce25-23bf-47e5-b127-0f7fb7194188"), StudentId = Guid.Parse("c8c5dab5-28e5-4d07-b450-3590f738393c"), Score = new decimal(8.4) },
                    new Grade { Id = Guid.Parse("a6286eee-9230-4d23-b405-1483204b9356"), CourseId = Guid.Parse("5315ce25-23bf-47e5-b127-0f7fb7194199"), StudentId = Guid.Parse("c8c5dab5-28e5-4d07-b450-3590f738391a"), Score = new decimal(9.2) },
                    new Grade { Id = Guid.Parse("a6286eee-9230-4d23-b405-1483204b9357"), CourseId = Guid.Parse("5315ce25-23bf-47e5-b127-0f7fb7194199"), StudentId = Guid.Parse("c8c5dab5-28e5-4d07-b450-3590f738392b"), Score = new decimal(5.0) },
                    new Grade { Id = Guid.Parse("a6286eee-9230-4d23-b405-1483204b9358"), CourseId = Guid.Parse("5315ce25-23bf-47e5-b127-0f7fb7194199"), StudentId = Guid.Parse("c8c5dab5-28e5-4d07-b450-3590f738393c"), Score = new decimal(4.1) }

                );

            }

            context.SaveChanges();
        }
    }
}
