﻿using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentApp
{
    /// <summary>
    /// Логика взаимодействия для TimetableWindow.xaml
    /// </summary>
    public partial class TimetableWindow : Window
    {
        Course course;
        Repository repository;
        public TimetableWindow(Repository repository, Course course)
        {
            InitializeComponent();
            this.course = course;
            this.repository = repository;
            ListBoxLessons.ItemsSource = repository.Lessons.Where(x => x.Course == course);
        }
    }
}
