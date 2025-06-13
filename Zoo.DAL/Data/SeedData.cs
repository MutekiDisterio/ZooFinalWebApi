using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zoo.DAL.Entity;
using System.Threading.Tasks;

namespace Zoo.DAL.Data
{
    public static class SeedData
    {

        public static void SeedDatao(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasData(
                new Owner { Id = 1, Name = "Georgi Georgiev", PhoneNumber = "0883456586", Address = "Sofia, 2 Zdrave str." },
                new Owner { Id = 2, Name = "Petur Petrov", PhoneNumber = "0897635645", Address = "Varna, 5 Dragoman str." },
                new Owner { Id = 3, Name = "Gergana Mancheva", PhoneNumber = "0897412123", Address = "Gabrovo, 21 Vasil Levski str." },
                new Owner { Id = 4, Name = "Kaloqn Stoqnov", PhoneNumber = "0878325642", Address = null },
                new Owner { Id = 5, Name = "Stamat Kostov", PhoneNumber = "0857231001", Address = "Plovdiv" },
                new Owner { Id = 6, Name = "Milena Dragomirova", PhoneNumber = "0876542123", Address = "Sofia, 213 Pirin str." },
                new Owner { Id = 7, Name = "Kiril Peshev", PhoneNumber = "0838654111", Address = "Sliven, 54 Struma str." },
                new Owner { Id = 8, Name = "Krasen Lyubenov", PhoneNumber = "0788120333", Address = "Stara Zagora, 2 Trakia str." },
                new Owner { Id = 9, Name = "Martin Genchev", PhoneNumber = "0899452325", Address = "Varna, 45 Devnya str." },
                new Owner { Id = 10, Name = "Kamelia Yancheva", PhoneNumber = "0876213799", Address = "Burgas, 21 Alexandrovska str." },
                new Owner { Id = 11, Name = "Metodi Dimitrov", PhoneNumber = "0894568889", Address = null },
                new Owner { Id = 12, Name = "Matei Kirilov", PhoneNumber = "0978235641", Address = "Kalofer, 2 Mladost str." },
                new Owner { Id = 13, Name = "Dobrin Krustev", PhoneNumber = "0978235641", Address = "Blagoevgrad, 2 Akacia str." },
                new Owner { Id = 14, Name = "Kaloyan Dobrev", PhoneNumber = "0896523145", Address = "Gorna Oryahovitsa, 12 Angel Georgiev str." },
                new Owner { Id = 15, Name = "Miroslav Kirilov", PhoneNumber = "0874563214", Address = "Sofia, 156 Mladost str." },
                new Owner { Id = 16, Name = "Krasen Stoyanov", PhoneNumber = "0896333258", Address = "Plovdiv, 18 Baba Tonka str." },
                new Owner { Id = 17, Name = "Bozhidara Stoicheva", PhoneNumber = "0874569123", Address = "Provadia, 1 Buk str." },
                new Owner { Id = 18, Name = "Petya Dobreva", PhoneNumber = "0874547896", Address = "Varna, 65 Vihren str." },
                new Owner { Id = 19, Name = "Kristina Kirova", PhoneNumber = "0888655632", Address = "Varna, 118 General Kolev str." },
                new Owner { Id = 20, Name = "Mila Sotirova", PhoneNumber = "0877456222", Address = "Burgas, 15 Glarus str." },
                new Owner { Id = 21, Name = "Grigor Litov", PhoneNumber = "0899366584", Address = "Sofia, 35 Detelina str." },
                new Owner { Id = 22, Name = "Karolina Dukova", PhoneNumber = "0894562123", Address = "Sliven, 8 Dobrotitsa str." },
                new Owner { Id = 23, Name = "Ivan Fotinov", PhoneNumber = "0879654125", Address = "Petrich, 9 Zora str." },
                new Owner { Id = 24, Name = "Anelia Mihova", PhoneNumber = "0897856147", Address = "Varna, 29 Dunav str." },
                new Owner { Id = 25, Name = "Stanislav Peshev", PhoneNumber = "0889699599", Address = "Sofia, 22 Karamfil str." },
                new Owner { Id = 26, Name = "Borislava Kamenova", PhoneNumber = "0877477112", Address = "Burgas, 15 Marek str." }
            );

            
            modelBuilder.Entity<AnimalType>().HasData(
                new AnimalType { Id = 1, AnimalTypeName = "Mammals" },
                new AnimalType { Id = 2, AnimalTypeName = "Fish" },
                new AnimalType { Id = 3, AnimalTypeName = "Birds" },
                new AnimalType { Id = 4, AnimalTypeName = "Reptiles" },
                new AnimalType { Id = 5, AnimalTypeName = "Amphibians" },
                new AnimalType { Id = 6, AnimalTypeName = "Invertebrates" }
            );

            
            modelBuilder.Entity<Cage>().HasData(
                new Cage { Id = 1, AnimalTypeId = 2 },
                new Cage { Id = 2, AnimalTypeId = 3 },
                new Cage { Id = 3, AnimalTypeId = 6 },
                new Cage { Id = 4, AnimalTypeId = 2 },
                new Cage { Id = 5, AnimalTypeId = 4 },
                new Cage { Id = 6, AnimalTypeId = 3 },
                new Cage { Id = 7, AnimalTypeId = 1 },
                new Cage { Id = 8, AnimalTypeId = 5 },
                new Cage { Id = 9, AnimalTypeId = 5 },
                new Cage { Id = 10, AnimalTypeId = 2 },
                new Cage { Id = 11, AnimalTypeId = 4 },
                new Cage { Id = 12, AnimalTypeId = 5 },
                new Cage { Id = 13, AnimalTypeId = 5 },
                new Cage { Id = 14, AnimalTypeId = 6 },
                new Cage { Id = 15, AnimalTypeId = 1 },
                new Cage { Id = 16, AnimalTypeId = 1 },
                new Cage { Id = 17, AnimalTypeId = 2 },
                new Cage { Id = 18, AnimalTypeId = 2 },
                new Cage { Id = 19, AnimalTypeId = 3 },
                new Cage { Id = 20, AnimalTypeId = 4 },
                new Cage { Id = 21, AnimalTypeId = 1 },
                new Cage { Id = 22, AnimalTypeId = 6 },
                new Cage { Id = 23, AnimalTypeId = 4 },
                new Cage { Id = 24, AnimalTypeId = 4 },
                new Cage { Id = 25, AnimalTypeId = 2 },
                new Cage { Id = 26, AnimalTypeId = 1 },
                new Cage { Id = 27, AnimalTypeId = 1 },
                new Cage { Id = 28, AnimalTypeId = 4 },
                new Cage { Id = 29, AnimalTypeId = 3 },
                new Cage { Id = 30, AnimalTypeId = 5 },
                new Cage { Id = 31, AnimalTypeId = 4 },
                new Cage { Id = 32, AnimalTypeId = 1 },
                new Cage { Id = 33, AnimalTypeId = 3 },
                new Cage { Id = 34, AnimalTypeId = 1 },
                new Cage { Id = 35, AnimalTypeId = 5 },
                new Cage { Id = 36, AnimalTypeId = 3 },
                new Cage { Id = 37, AnimalTypeId = 1 },
                new Cage { Id = 38, AnimalTypeId = 1 },
                new Cage { Id = 39, AnimalTypeId = 3 },
                new Cage { Id = 40, AnimalTypeId = 5 },
                new Cage { Id = 41, AnimalTypeId = 1 },
                new Cage { Id = 42, AnimalTypeId = 2 },
                new Cage { Id = 43, AnimalTypeId = 5 },
                new Cage { Id = 44, AnimalTypeId = 4 },
                new Cage { Id = 45, AnimalTypeId = 3 },
                new Cage { Id = 46, AnimalTypeId = 3 },
                new Cage { Id = 47, AnimalTypeId = 2 },
                new Cage { Id = 48, AnimalTypeId = 1 },
                new Cage { Id = 49, AnimalTypeId = 1 },
                new Cage { Id = 50, AnimalTypeId = 5 },
                new Cage { Id = 51, AnimalTypeId = 4 },
                new Cage { Id = 52, AnimalTypeId = 1 },
                new Cage { Id = 53, AnimalTypeId = 4 },
                new Cage { Id = 54, AnimalTypeId = 2 },
                new Cage { Id = 55, AnimalTypeId = 3 }
            );

            modelBuilder.Entity<Animal>().HasData(
                new Animal { Id = 1, Name = "Brown bear", BirthDate = new DateTime(2017, 07, 17, 0, 0, 0, DateTimeKind.Utc), OwnerId = 3, AnimalTypeId = 1 },
                new Animal { Id = 2, Name = "Chimpanzee", BirthDate = new DateTime(2010, 01, 21, 0, 0, 0, DateTimeKind.Utc), OwnerId = 6, AnimalTypeId = 1 },
                new Animal { Id = 3, Name = "Chinchilla", BirthDate = new DateTime(2019, 11, 01, 0, 0, 0, DateTimeKind.Utc), OwnerId = 11, AnimalTypeId = 1 },
                new Animal { Id = 4, Name = "Elephant", BirthDate = new DateTime(2009, 05, 18, 0, 0, 0, DateTimeKind.Utc), OwnerId = 4, AnimalTypeId = 1 },
                new Animal { Id = 5, Name = "Lion", BirthDate = new DateTime(2018, 06, 28, 0, 0, 0, DateTimeKind.Utc), OwnerId = 10, AnimalTypeId = 1 },
                new Animal { Id = 6, Name = "Rhinoceros", BirthDate = new DateTime(2011, 12, 24, 0, 0, 0, DateTimeKind.Utc), OwnerId = 2, AnimalTypeId = 1 },
                new Animal { Id = 7, Name = "Wolf", BirthDate = new DateTime(2018, 03, 09, 0, 0, 0, DateTimeKind.Utc), OwnerId = 7, AnimalTypeId = 1 },
                new Animal { Id = 8, Name = "Leopard", BirthDate = new DateTime(2017, 04, 17, 0, 0, 0, DateTimeKind.Utc), OwnerId = 4, AnimalTypeId = 1 },
                new Animal { Id = 9, Name = "Fennec Fox", BirthDate = new DateTime(2015, 09, 10, 0, 0, 0, DateTimeKind.Utc), OwnerId = 26, AnimalTypeId = 1 },
                new Animal { Id = 10, Name = "Giant Panda", BirthDate = new DateTime(2021, 11, 11, 0, 0, 0, DateTimeKind.Utc), OwnerId = 18, AnimalTypeId = 1 },
                new Animal { Id = 11, Name = "Hippo", BirthDate = new DateTime(2017, 09, 07, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 1 },
                new Animal { Id = 12, Name = "Koala", BirthDate = new DateTime(2018, 06, 30, 0, 0, 0, DateTimeKind.Utc), OwnerId = 24, AnimalTypeId = 1 },
                new Animal { Id = 13, Name = "Pumpkinseed Sunfish", BirthDate = new DateTime(2020, 11, 04, 0, 0, 0, DateTimeKind.Utc), OwnerId = 10, AnimalTypeId = 2 },
                new Animal { Id = 14, Name = "Banded Archer Fish", BirthDate = new DateTime(2022, 01, 15, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 2 },
                new Animal { Id = 15, Name = "Cichlid", BirthDate = new DateTime(2021, 01, 21, 0, 0, 0, DateTimeKind.Utc), OwnerId = 5, AnimalTypeId = 2 },
                new Animal { Id = 16, Name = "Koi", BirthDate = new DateTime(2021, 07, 05, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 2 },
                new Animal { Id = 17, Name = "West African Lungfish", BirthDate = new DateTime(2019, 10, 17, 0, 0, 0, DateTimeKind.Utc), OwnerId = 4, AnimalTypeId = 2 },
                new Animal { Id = 18, Name = "Leopard Shark", BirthDate = new DateTime(2018, 02, 16, 0, 0, 0, DateTimeKind.Utc), OwnerId = 16, AnimalTypeId = 2 },
                new Animal { Id = 19, Name = "Tufted Puffin", BirthDate = new DateTime(2017, 10, 31, 0, 0, 0, DateTimeKind.Utc), OwnerId = 8, AnimalTypeId = 3 },
                new Animal { Id = 20, Name = "Saddlebill Stork", BirthDate = new DateTime(2019, 08, 21, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 3 },
                new Animal { Id = 21, Name = "Ostrich", BirthDate = new DateTime(2016, 05, 02, 0, 0, 0, DateTimeKind.Utc), OwnerId = 4, AnimalTypeId = 3 },
                new Animal { Id = 22, Name = "Bald Eagle", BirthDate = new DateTime(2014, 06, 29, 0, 0, 0, DateTimeKind.Utc), OwnerId = 12, AnimalTypeId = 3 },
                new Animal { Id = 23, Name = "Swan Goose", BirthDate = new DateTime(2018, 11, 12, 0, 0, 0, DateTimeKind.Utc), OwnerId = 9, AnimalTypeId = 3 },
                new Animal { Id = 24, Name = "Northern Pintail Duck", BirthDate = new DateTime(2019, 02, 15, 0, 0, 0, DateTimeKind.Utc), OwnerId = 6, AnimalTypeId = 3 },
                new Animal { Id = 25, Name = "African Penguin", BirthDate = new DateTime(2017, 07, 17, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 3 },
                new Animal { Id = 26, Name = "American Kestrel", BirthDate = new DateTime(2019, 04, 27, 0, 0, 0, DateTimeKind.Utc), OwnerId = 18, AnimalTypeId = 3 },
                new Animal { Id = 27, Name = "California Condor", BirthDate = new DateTime(2014, 12, 19, 0, 0, 0, DateTimeKind.Utc), OwnerId = 16, AnimalTypeId = 3 },
                new Animal { Id = 28, Name = "African Spurred Tortoise", BirthDate = new DateTime(2009, 09, 26, 0, 0, 0, DateTimeKind.Utc), OwnerId = 7, AnimalTypeId = 4 },
                new Animal { Id = 29, Name = "Anaconda", BirthDate = new DateTime(2016, 07, 13, 0, 0, 0, DateTimeKind.Utc), OwnerId = 10, AnimalTypeId = 4 },
                new Animal { Id = 30, Name = "Boa", BirthDate = new DateTime(2015, 08, 21, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 4 },
                new Animal { Id = 31, Name = "Chameleon", BirthDate = new DateTime(2018, 10, 07, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 4 },
                new Animal { Id = 32, Name = "Crocodilian", BirthDate = new DateTime(2016, 01, 11, 0, 0, 0, DateTimeKind.Utc), OwnerId = 11, AnimalTypeId = 4 },
                new Animal { Id = 33, Name = "Iguana", BirthDate = new DateTime(2019, 04, 29, 0, 0, 0, DateTimeKind.Utc), OwnerId = 6, AnimalTypeId = 4 },
                new Animal { Id = 34, Name = "Lizard", BirthDate = new DateTime(2020, 12, 02, 0, 0, 0, DateTimeKind.Utc), OwnerId = 7, AnimalTypeId = 4 },
                new Animal { Id = 35, Name = "Tuatara", BirthDate = new DateTime(2021, 06, 18, 0, 0, 0, DateTimeKind.Utc), OwnerId = 14, AnimalTypeId = 4 },
                new Animal { Id = 36, Name = "Woma Python", BirthDate = new DateTime(2019, 04, 26, 0, 0, 0, DateTimeKind.Utc), OwnerId = 19, AnimalTypeId = 4 },
                new Animal { Id = 37, Name = "Rattlesnake", BirthDate = new DateTime(2017, 12, 02, 0, 0, 0, DateTimeKind.Utc), OwnerId = 19, AnimalTypeId = 4 },
                new Animal { Id = 38, Name = "Goliath Frog", BirthDate = new DateTime(2020, 01, 31, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 5 },
                new Animal { Id = 39, Name = "Poison Frog", BirthDate = new DateTime(2020, 07, 13, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 5 },
                new Animal { Id = 40, Name = "Mantella", BirthDate = new DateTime(2022, 03, 21, 0, 0, 0, DateTimeKind.Utc), OwnerId = 9, AnimalTypeId = 5 },
                new Animal { Id = 41, Name = "Surinam Toad", BirthDate = new DateTime(2021, 06, 15, 0, 0, 0, DateTimeKind.Utc), OwnerId = 11, AnimalTypeId = 5 },
                new Animal { Id = 42, Name = "Axolotl", BirthDate = new DateTime(2019, 01, 21, 0, 0, 0, DateTimeKind.Utc), OwnerId = 12, AnimalTypeId = 5 },
                new Animal { Id = 43, Name = "Panamanian Golden Frog", BirthDate = new DateTime(2021, 09, 30, 0, 0, 0, DateTimeKind.Utc), OwnerId = 23, AnimalTypeId = 5 },
                new Animal { Id = 44, Name = "Desert Hairy Scorpion", BirthDate = new DateTime(2020, 05, 13, 0, 0, 0, DateTimeKind.Utc), OwnerId = null, AnimalTypeId = 6 },
                new Animal { Id = 45, Name = "Madagascar Hissing Cockroach", BirthDate = new DateTime(2021, 09, 10, 0, 0, 0, DateTimeKind.Utc), OwnerId = 7, AnimalTypeId = 6 },
                new Animal { Id = 46, Name = "Sunburst Diving Beetle", BirthDate = new DateTime(2022, 01, 05, 0, 0, 0, DateTimeKind.Utc), OwnerId = 9, AnimalTypeId = 6 }
            );

            modelBuilder.Entity<AnimalCage>().HasData(
                new AnimalCage { CageId = 1, AnimalId = 13 },
                new AnimalCage { CageId = 2, AnimalId = 19 },
                new AnimalCage { CageId = 3, AnimalId = 44 },
                new AnimalCage { CageId = 5, AnimalId = 32 },
                new AnimalCage { CageId = 6, AnimalId = 24 },
                new AnimalCage { CageId = 7, AnimalId = 5 },
                new AnimalCage { CageId = 8, AnimalId = 41 },
                new AnimalCage { CageId = 9, AnimalId = 38 },
                new AnimalCage { CageId = 10, AnimalId = 16 },
                new AnimalCage { CageId = 11, AnimalId = 28 },
                new AnimalCage { CageId = 12, AnimalId = 39 },
                new AnimalCage { CageId = 14, AnimalId = 45 },
                new AnimalCage { CageId = 15, AnimalId = 7 },
                new AnimalCage { CageId = 16, AnimalId = 12 },
                new AnimalCage { CageId = 18, AnimalId = 14 },
                new AnimalCage { CageId = 19, AnimalId = 26 },
                new AnimalCage { CageId = 20, AnimalId = 36 },
                new AnimalCage { CageId = 21, AnimalId = 9 },
                new AnimalCage { CageId = 22, AnimalId = 46 },
                new AnimalCage { CageId = 23, AnimalId = 34 },
                new AnimalCage { CageId = 24, AnimalId = 37 },
                new AnimalCage { CageId = 26, AnimalId = 1 },
                new AnimalCage { CageId = 27, AnimalId = 10 },
                new AnimalCage { CageId = 28, AnimalId = 33 },
                new AnimalCage { CageId = 29, AnimalId = 20 },
                new AnimalCage { CageId = 31, AnimalId = 31 },
                new AnimalCage { CageId = 32, AnimalId = 8 },
                new AnimalCage { CageId = 33, AnimalId = 27 },
                new AnimalCage { CageId = 34, AnimalId = 3 },
                new AnimalCage { CageId = 35, AnimalId = 42 },
                new AnimalCage { CageId = 36, AnimalId = 22 },
                new AnimalCage { CageId = 37, AnimalId = 4 },
                new AnimalCage { CageId = 38, AnimalId = 11 },
                new AnimalCage { CageId = 39, AnimalId = 21 },
                new AnimalCage { CageId = 41, AnimalId = 6 },
                new AnimalCage { CageId = 42, AnimalId = 18 },
                new AnimalCage { CageId = 43, AnimalId = 40 },
                new AnimalCage { CageId = 44, AnimalId = 35 },
                new AnimalCage { CageId = 46, AnimalId = 25 },
                new AnimalCage { CageId = 47, AnimalId = 15 },
                new AnimalCage { CageId = 49, AnimalId = 2 },
                new AnimalCage { CageId = 50, AnimalId = 43 },
                new AnimalCage { CageId = 51, AnimalId = 30 },
                new AnimalCage { CageId = 53, AnimalId = 29 },
                new AnimalCage { CageId = 54, AnimalId = 17 },
                new AnimalCage { CageId = 55, AnimalId = 23 }
            );

            modelBuilder.Entity<VolunteerDepartment>().HasData(
                new VolunteerDepartment { Id = 1, DepartmentName = "Guest engagement" },
                new VolunteerDepartment { Id = 2, DepartmentName = "Education program assistant" },
                new VolunteerDepartment { Id = 3, DepartmentName = "Zoo events" },
                new VolunteerDepartment { Id = 4, DepartmentName = "Animal encounters" },
                new VolunteerDepartment { Id = 5, DepartmentName = "Interpretive volunteer" },
                new VolunteerDepartment { Id = 6, DepartmentName = "Keeper aide" },
                new VolunteerDepartment { Id = 7, DepartmentName = "Animal handler" },
                new VolunteerDepartment { Id = 8, DepartmentName = "Horticulture" }
            );

            modelBuilder.Entity<Volunteer>().HasData(
                new Volunteer { Id = 1, Name = "Kiril Kostadinov", PhoneNumber = "0896541233", Address = "Sofia , 213 Tsarigradsko shose str.", AnimalId = 7, DepartmentId = 2 },
                new Volunteer { Id = 2, Name = "Boyan Boyanov", PhoneNumber = "0896321546", Address = "Plovdiv, 15 Arda str.", AnimalId = 14, DepartmentId = 1 },
                new Volunteer { Id = 3, Name = "Mariya Petkova", PhoneNumber = "0874563201", Address = "Kalofer, 2 Tsar Simeon str.", AnimalId = 4, DepartmentId = 3 },
                new Volunteer { Id = 4, Name = "Svilen Mitev", PhoneNumber = "0877300100", Address = null, AnimalId = 8, DepartmentId = 4 },
                new Volunteer { Id = 5, Name = "Dimitrichka Stateva", PhoneNumber = "0888632123", Address = "Sofia, 26 Vasil Levski str.", AnimalId = 7, DepartmentId = 8 },
                new Volunteer { Id = 6, Name = "Anton Antonov", PhoneNumber = "0877456123", Address = "Varna, 2 Dobrotitsa str.", AnimalId = 11, DepartmentId = 3 },
                new Volunteer { Id = 7, Name = "Yanko Totev", PhoneNumber = "0896369258", Address = "Sofia, 54 Hristo Botev str.", AnimalId = 1, DepartmentId = 2 },
                new Volunteer { Id = 8, Name = "Katerina Dimitrova", PhoneNumber = "0874589665", Address = null, AnimalId = 5, DepartmentId = 6 },
                new Volunteer { Id = 9, Name = "Paskal Shopov", PhoneNumber = "0888987110", Address = "Gorna Oryahovitsa, 5 Otez Paisii str.", AnimalId = null, DepartmentId = 4 },
                new Volunteer { Id = 10, Name = "Darina Petrova", PhoneNumber = "0889654236", Address = "Sofia, 39 Bratya Buxton str.", AnimalId = 31, DepartmentId = 3 },
                new Volunteer { Id = 11, Name = "Maya Stoyanova", PhoneNumber = "0886544444", Address = "Karlovo, 2 Breza str.", AnimalId = 29, DepartmentId = 1 },
                new Volunteer { Id = 12, Name = "Svilen Moskov", PhoneNumber = "0879510023", Address = "Sofia, 61 Veles str.", AnimalId = 27, DepartmentId = 5 },
                new Volunteer { Id = 13, Name = "Georgi Georgiev", PhoneNumber = "0879654456", Address = "Varna, 23 Devnya str.", AnimalId = 16, DepartmentId = 6 },
                new Volunteer { Id = 14, Name = "Vasil Vasilev", PhoneNumber = "0896321023", Address = "Varna, 2 Elin Pelin str.", AnimalId = null, DepartmentId = 7 },
                new Volunteer { Id = 15, Name = "Krasimira Boyanova", PhoneNumber = "0879541236", Address = "Montana, 2 Zora str.", AnimalId = 2, DepartmentId = 2 },
                new Volunteer { Id = 16, Name = "Teodora Stanoeva", PhoneNumber = "0887986002", Address = "Sofia, 37 Iglika str.", AnimalId = 33, DepartmentId = 1 },
                new Volunteer { Id = 17, Name = "Gabriel Radkov", PhoneNumber = "0889745102", Address = "Sliven, 6 Krim str.", AnimalId = 18, DepartmentId = 5 },
                new Volunteer { Id = 18, Name = "Mihail Boev", PhoneNumber = "0896336554", Address = "Tryavna, 21 Loza str.", AnimalId = 11, DepartmentId = 2 },
                new Volunteer { Id = 19, Name = "Dilyana Stoeva", PhoneNumber = "0889412025", Address = "Sofia , 15 Lyulyak str.", AnimalId = null, DepartmentId = 2 },
                new Volunteer { Id = 20, Name = "Yulian Bratoev", PhoneNumber = "0897665895", Address = "Varna, 158 Mariya Luiza str.", AnimalId = 16, DepartmentId = 1 },
                new Volunteer { Id = 21, Name = "Petya Dobreva", PhoneNumber = "0888541236", Address = "Ahtopol, 11 Mir str.", AnimalId = 13, DepartmentId = 3 },
                new Volunteer { Id = 22, Name = "Zdravko Asenov", PhoneNumber = "0889652365", Address = "Sofia, 6 Neven str.", AnimalId = 19, DepartmentId = 2 },
                new Volunteer { Id = 23, Name = "Stefan Lazarov", PhoneNumber = "0887456215", Address = "Veliko Turnovo, 54 Odrin str.", AnimalId = 22, DepartmentId = 3 },
                new Volunteer { Id = 24, Name = "Radoslava Mihailova", PhoneNumber = "0887456325", Address = "Plovdiv, 16 Pirin str.", AnimalId = 34, DepartmentId = 6 }
            );
        }
    }


}








