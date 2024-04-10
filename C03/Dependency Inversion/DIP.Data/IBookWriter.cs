﻿namespace DependencyInversionPrinciple.Data
{
    public interface IBookWriter
    {
        void Create(Book book);
        void Replace(Book book);
        void Remove(Book book);
    }
}
