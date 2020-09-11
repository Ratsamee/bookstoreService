﻿namespace bookstoreService.Model
{
    public class SignIn
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SignInUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}