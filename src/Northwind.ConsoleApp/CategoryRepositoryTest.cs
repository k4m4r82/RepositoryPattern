using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Northwind.Model;
using Northwind.Repository.Api;
using Northwind.Repository.Service;

namespace Northwind.ConsoleApp
{
    class CategoryRepositoryTest
    {
        // deklarsi objek repository
        static ICategoryRepository _repository;

        static void Main(string[] args)
        {
            // buat objek context
            IDapperContext context = new DapperContext();

            // buat objek repository, dengan melewatkan objek context via consturctor
            _repository = new CategoryRepository(context);

            // tes method GetAll, Save, Update dan Delete
            GetAllTest();
            //SaveTest();
            //UpdateTest();
            //DeleteTest();

            Console.WriteLine("\nPress any key to exit ...");
            Console.ReadKey();
        }

        static void GetAllTest()
        {
            var listOfCategory = _repository.GetAll();
            foreach (var category in listOfCategory)
            {
                Console.WriteLine("{0}, {1}, {2}", category.CategoryID, category.CategoryName, category.Description);
            }
        }

        static void SaveTest()
        {
            var category = new Category
            {
                CategoryName = "Seafood",
                Description = "Seaweed and fish"
            };

            var result = _repository.Save(category);
            Console.WriteLine("Tambah data baru {0}", result > 0 ? "berhasil" : "gagal");
        }

        static void UpdateTest()
        {
            var categoryId = 20;
            var category = _repository.GetByID(categoryId);

            category.CategoryName = "Seaweed and fish";
            category.Description = "Seafood";

            var result = _repository.Update(category);
            Console.WriteLine("Update data {0}", result > 0 ? "berhasil" : "gagal");
        }

        static void DeleteTest()
        {
            var categoryId = 20;
            var category = _repository.GetByID(categoryId);

            var result = _repository.Delete(category);
            Console.WriteLine("Menghapus data {0}", result > 0 ? "berhasil" : "gagal");
        }        
    }
}
