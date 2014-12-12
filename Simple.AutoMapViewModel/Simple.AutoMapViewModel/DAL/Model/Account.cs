using System;

namespace Simple.AutoMapViewModel.DAL.Model
{
    public class Account
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public string Password { get; set; }
    }
}