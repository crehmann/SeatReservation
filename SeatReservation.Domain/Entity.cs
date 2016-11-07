﻿using System;

namespace SeatReservation.Domain
{
    public abstract class Entity
    {
        public virtual Guid Id { get; protected internal set; }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (Id == Guid.Empty || other.Id == Guid.Empty)
                return false;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();
    }
}