using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsData.Models;

public class AnimalType
{
    public int Id { get; set; } 
    public string Name { get; set; }

    public PetCategory Pet { get; set; }

    public int PetId { get; set; }


}
