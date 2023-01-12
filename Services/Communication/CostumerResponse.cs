using Dws.Note_one.Api.Domain.Models;

namespace Dws.Note_one.Api.Services.Communication
{

    public class CostumerResponse : BaseResponse
    {
        public Costumer Costumer { get; private set; }

        private CostumerResponse(bool success, string message, Costumer costumer) : base(success, message)
        {
            Costumer = costumer;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="costumer">Saved Costumer.</param>
        /// <returns>Response.</returns>
        public CostumerResponse(Costumer costumer) : this(true, string.Empty, costumer)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CostumerResponse(string message) : this(false, message, null)
        { }
    }
}