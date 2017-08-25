using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Models {
  public class TodoItem {

    public int Id { get; set; }

    [StringLength(150)]
    public string Description { get; set; }

    public bool IsDone { get; set; } = false;

    public DateTime AddedDate { get; set; } = DateTime.Now;

    [StringLength(40)]
    public string OwnerId { get; set; }

    public DateTime? CompletedDate { get; set; } = null;


    public void MarkAsComplete() {
      IsDone = true;
      CompletedDate = DateTime.Now;
    }

    public void CancelComplete() {
      IsDone = false;
      CompletedDate = null;
    }
  }
}
