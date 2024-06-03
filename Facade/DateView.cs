﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Facade;
public abstract class DateView : EntityView
{
    [DisplayName("FromDate")][Required] public DateTime FromDate { get; set; }
    [DisplayName("ThruDate")][Required] public DateTime? ThruDate { get; set; }
}