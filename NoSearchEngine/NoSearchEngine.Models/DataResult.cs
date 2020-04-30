﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NoSearchEngine.Models
{
    public class DataResult<T>
    {
        public bool IsSuccess { get; set; }
        public string[] Errors { get; set; }
        public T Data { get; set; }

        public static DataResult<T> Success(T data) =>        
            new DataResult<T>()
            {
                IsSuccess = true,
                Data = data
            };

        public static DataResult<T> Error(string[] errors) =>
            new DataResult<T>()
            {
                IsSuccess = false,
                Errors = errors                
            };

        public static DataResult<T> Error(string error) =>
            new DataResult<T>()
            {
                IsSuccess = false,
                Errors = new[] { error }
            };

        public static DataResult<T> Error(T data, string error) =>
            new DataResult<T>()
            {
                IsSuccess = false,
                Errors = new[] { error },
                Data = data
            };

    }
}
