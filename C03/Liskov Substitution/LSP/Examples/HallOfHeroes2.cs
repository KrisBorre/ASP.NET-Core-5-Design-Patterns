﻿using LiskovSubstitutionPrinciple.Models;
using System;

namespace LiskovSubstitutionPrinciple.Examples.Update2
{
    public class HallOfHeroes : HallOfFame
    {
        public override void Add(Ninja ninja)
        {
            if (InternalMembers.Contains(ninja))
            {
                throw new DuplicateNinjaException();
            }
            InternalMembers.Add(ninja);
        }
    }

    public class DuplicateNinjaException : Exception
    {
        public DuplicateNinjaException()
            : base("Cannot add the same ninja twice!") { }
    }
}
