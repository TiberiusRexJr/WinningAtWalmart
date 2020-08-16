using System;
using System.Collections.Generic;
using System.Text;

namespace WinningAtWalmart.Models
{
    public class Worker
    {
        #region Variables
        #endregion
        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Worker> ShowAllWorkers { get; set; }
        #endregion
        #region Implementations
        #endregion
        #region Constructor

        #endregion
        #region Functions
        #endregion
    }
}
