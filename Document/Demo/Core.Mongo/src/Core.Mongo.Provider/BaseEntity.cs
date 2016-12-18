using System;
using System.Collections.Generic;

namespace Core.Mongo.Provider
{
    public interface IEntityBase<T>
    {
        T Id { get; }
    }
    public abstract class AggregateBase : IEntityBase<Guid>
    {
        public Guid Id { get; private set; }
        public AggregateBase()
        {
            Id = Guid.NewGuid();
        }
    }
    public interface IValueObject
    {
        Guid Id { get; }
    }
    public abstract class ValueObjectBase
    {
        public Guid Id { get; }

        public ValueObjectBase()
        {
            Id = Guid.NewGuid();
        }
    }
    public abstract class NavgationBase
    {
        public virtual Guid AggregateId { get; set; }
        public virtual Guid ValueObjectId { get; set; }
    }
    public class User : AggregateBase
    {
        public string Name { get; set; }
        public string Pwd { get; set; }
        public int Number { get; set; }
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }

    public class Role : AggregateBase, IValueObject
    {
        public int Number { get; set; }
        public Guid UserGId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }


    public class Permission : ValueObjectBase
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool HavePermission { get; set; } = true;
    }
    public class User_Role : NavgationBase
    {
    }
    public class Role_Permission : NavgationBase
    {
    }
    public class User_Permission : NavgationBase
    {
    }
}
