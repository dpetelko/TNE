using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos
{
    public enum Status
    {
        [Display(Name = "Работа")]
        InWork = 1,
        [Display(Name = "Склад")]
        InStorage = 0,
        [Display(Name = "Ремонт")]
        UnderRepair = 2,
        [Display(Name = "Списан")]
        Dismiss = 3
    }
}
