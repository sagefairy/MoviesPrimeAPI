using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace MoviesPrimeApi.Models
{
    public static class MovieBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "Little Women", Description = "In flashbacks, aspiring author Jo and her sisters -- Meg, Beth and Amy -- welcome their new neighbor, Laurie, into their creative inner circle as they help their Marmee hold down the homestead while their father serves in the Civil War.", Genre = "Realistic Fiction" },
                new Movie { Id = 2, Name = "Black Swan", Description = "Nina is a talented but unstable ballerina on the verge of stardom. Pushed to the breaking point by her artistic director and a seductive rival, Nina's grip on reality slips, plunging her into a waking nightmare.", Genre = "Thriller" },
                new Movie { Id = 3, Name = "The Beguiled", Description = "The unexpected arrival of a wounded Union soldier at a girls school in Virginia during the American Civil War leads to jealousy and betrayal.\r\n\r\n    Director\r\n        Sofia Coppola", Genre = "Drama" },
                new Movie { Id = 4, Name = "White Chicks", Description = "Two disgraced FBI agents go way undercover in an effort to protect hotel heiresses the Wilson sisters from a kidnapping plot.", Genre = "Comedy" },
                new Movie { Id = 5, Name = "Guava Island", Description = "A young musician seeks to hold a festival to liberate the oppressed people of Guava Island, even if only for a day.", Genre = "Drama" },
                new Movie { Id = 6, Name = "Hairspray", Description = "Pleasantly plump teenager Tracy Turnblad teaches 1962 Baltimore a thing or two about integration after landing a spot on a local TV dance show.", Genre = "Musical" },
                new Movie { Id = 7, Name = "Pearl", Description = "In 1918, a young woman on the brink of madness pursues stardom in a desperate attempt to escape the drudgery, isolation, and lovelessness of life on her parents' farm.", Genre = "Thriller" },
                new Movie { Id = 8, Name = "The Dreamers", Description = "A young American studying in Paris in 1968 strikes up a friendship with a French brother and sister. Set against the background of the '68 Paris student riots.", Genre = "Light Fiction" },
                new Movie { Id = 9, Name = "Atonement", Description = "Thirteen-year-old fledgling writer Briony Tallis irrevocably changes the course of several lives when she accuses her older sister's lover of a crime he did not commit.", Genre = "Drama" },
                new Movie { Id = 10, Name = "Lady Bird", Description = "In 2002, an artistically inclined 17-year-old girl comes of age in Sacramento, California.", Genre = "Drama" },
                new Movie { Id = 11, Name = "Atlantique", Description = "In a popular suburb of Dakar, workers on the construction site of a futuristic tower, without pay for months, decide to leave the country by the ocean for a better future. Among them is Souleiman, the lover of Ada, promised to another.", Genre = "Thriller" },
                new Movie { Id = 12, Name = "Girl,Interrupted", Description = "A directionless teenager, Susanna, is rushed to Claymoore, a mental institution, after a supposed suicide attempt. There, she befriends a group of troubled women who deeply influence her life.", Genre = "Psychological Drama" },
                new Movie { Id = 13, Name = "Water Lilies", Description = "After meeting at a local pool over their summer break, a love triangle forms between three adolescent girls, which proves difficult to sustain as they each desire the love of another.", Genre = "Coming-Of-Age" },
                new Movie { Id = 14, Name = "Sex and the City", Description = "A New York City writer on sex and love is finally getting married to her Mr. Big. But her three best girlfriends must console her after one of them inadvertently leads Mr. Big to jilt her.", Genre = "Romance/Sitcom" },
                new Movie { Id = 15, Name = "Perfect Blue", Description = "A pop singer gives up her career to become an actress, but she slowly goes insane when she starts being stalked by an obsessed fan and what seems to be a ghost of her past.", Genre = "Thriller" });


            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, Name = "Natalie Portman", MovieId = 2},
                new Actor { Id = 2, Name = "Mila Kunis", MovieId = 2 },
                new Actor { Id = 3, Name = "Emma Watson", MovieId = 1 },
                new Actor { Id = 4, Name = "Saoirse Roman", MovieId = 1 },
                new Actor { Id = 5, Name = "Timothee Chalamet", MovieId = 1},
                new Actor { Id = 6, Name = "Nicole Kidman", MovieId = 3 },
                new Actor { Id = 7, Name = "Kirsten Dunst", MovieId = 3 },
                new Actor { Id = 8, Name = "Elle Fanning", MovieId = 3 },
                new Actor { Id = 9, Name = "Marlon Wayans", MovieId = 4 },
                new Actor { Id = 10, Name = "Rihanna", MovieId = 5 },
                new Actor { Id = 11, Name = "Donald Glover ", MovieId = 5 },
                new Actor { Id = 12, Name = "Queen Latifah", MovieId = 6 },
                new Actor { Id = 13, Name = "Nikkie Blonsky", MovieId = 6 },
                new Actor { Id = 14, Name = "Mia Goth", MovieId = 7 },
                new Actor { Id = 15, Name = "Michael Pitt", MovieId = 8 },
                new Actor { Id = 16, Name = "Eva Green", MovieId = 8 },
                new Actor { Id = 17, Name = "Keira Knightley", MovieId = 9 },
                new Actor { Id = 18, Name = "James McAvoy", MovieId = 9 },
                new Actor { Id = 26, Name = "Saoirse Roman", MovieId = 10 },
                new Actor { Id = 27, Name = "Timothee Chalamet", MovieId = 10 },
                new Actor { Id = 19, Name = "Mame Bineta Sane", MovieId = 11 },
                new Actor { Id = 20, Name = "Angelina Jolie", MovieId = 12 },
                new Actor { Id = 21, Name = "Winona Ryder", MovieId = 12 },
                new Actor { Id = 22, Name = "Pauline Acquart", MovieId = 13 },
                new Actor { Id = 23, Name = "Adele Hanael", MovieId = 13 },
                new Actor { Id = 24, Name = "Sarah Jessica Parker", MovieId = 14 },
                new Actor { Id = 25, Name = "Kim Catrall", MovieId = 14 });
                
        }


    }
}
