﻿using ApiEBooks.Controllers;
using ApiEBooks.Models.Dto;
using ApiEBooks.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class CategoryTesting
    {
        private readonly CategoryController _controller;
        private readonly ICategoryService _service;

        public CategoryTesting()
        {
            _service = new CategoryService();
            _controller = new CategoryController(_service);
        }

        [Fact]
        public void Get_OK()
        {
            var result = _controller.Get();
            Assert.NotNull(result);
            Assert.IsAssignableFrom<ActionResult<IEnumerable<CategoryDto>>>(result);

            if (result is ActionResult<IEnumerable<CategoryDto>> actionResult)
            {
                var okResult = actionResult.Result as OkObjectResult;
                Assert.NotNull(okResult);

                // Luego, verifica el tipo del contenido.
                var content = okResult.Value;
                Assert.IsAssignableFrom<IEnumerable<CategoryDto>>(content);
            }
        }


        [Fact]
        public void Create_Returns()
        {

            var categoryService = new CategoryService();

            var newCategory = new CategoryDto
            {
                Id = 4, // Asigna un ID único para el nuevo autor.
                Name = "Nueva Category",

            };


            // Llama al método Create en AuthorService para agregar el autor.
            var addedCategory = categoryService.Create(newCategory);

            // Verifica que la categoria se haya agregado correctamente a _authors en AuthorService.
            Assert.Contains(addedCategory, CategoryService._categoryList);



        }

        [Fact]
        public void Update_Returns()
        {
            var existingCategory = new CategoryDto
            {
                Id = 4, // Asigna el mismo ID que deseas actualizar.
                Name = "Category o",

            };

            // Agrega la categoria existente a tu servicio antes de la prueba.
            _service.Create(existingCategory);

            // Modifica los datos del autor existente aquí.
            var updatedCategory = new CategoryDto
            {
                Id = 4, // Asigna el mismo ID que deseas actualizar.
                Name = "Category uodate",

            };

            var result = _controller.Update(existingCategory.Id, updatedCategory);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_Returns()
        {
            var categoryToDelete = new CategoryDto
            {
                // Configura los datos del autor que se va a eliminar aquí.
            };

            // Agrega el autor que se va a eliminar a tu servicio antes de la prueba.
            _service.Create(categoryToDelete);

            var result = _controller.Delete(categoryToDelete.Id);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
