// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the User type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.Domain.User
{
    using System;

    using RGM.BalancedScorecard.SharedKernel.Domain;


    /// <summary>
    /// The user.
    /// </summary>
    public class User : AggregateRoot<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public User(Guid id)
            : base(id)
        {
        }

        /// <summary>
        /// The validate.
        /// </summary>
        protected override void Validate()
        {
            
        }
    }
}