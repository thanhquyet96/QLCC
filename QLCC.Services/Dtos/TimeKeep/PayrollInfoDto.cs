using System;
namespace QLCC.Services.Dtos.TimeKeep
{
	public class PayrollInfoDto
	{
        public string FullName { get; set; }
        /// <summary>
        /// Hệ số lương
        /// </summary>
        public double CoefficientsSalary { get; set; }
        /// <summary>
        /// Nghỉ hưởng lương
        /// </summary>
        public double OnLeave { get; set; }
        /// <summary>
        /// Nghỉ không lương
        /// </summary>
        public double UnpaidLeave { get; set; }
        public string SUnpaidLeave { get; set; }
        /// <summary>
        /// TIền lương
        /// </summary>
        public decimal Salary { get; set; }
        public IDictionary<string, object> ValuePairs { get; set; }
    }
}

