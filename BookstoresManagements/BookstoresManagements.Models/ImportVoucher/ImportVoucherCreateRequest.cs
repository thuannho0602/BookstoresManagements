﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Models.ImportVoucher
{
    public class ImportVoucherCreateRequest
    {
        public int Id { get; set; }
        public DateTime? ImportDate { get; set; }
        public int? PublisherId { get; set; }
    }
}
