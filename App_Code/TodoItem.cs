﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MvcApplication6.Models
{
    /// <summary>
    /// Сущность рабочего элемента
    /// </summary>
    public class TodoItem
    {
        public int TodoItemId { get; set; }

        [Required]
        public string Title { get; set; }
        public bool IsDone { get; set; }

        [ForeignKey("TodoList")]
        public int TodoListId { get; set; }
        public virtual TodoList TodoList { get; set; }
    }
}