﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.calitha.goldparser;

namespace Epi.Core.EnterInterpreter.Rules
{

    public partial class Rule_Year : Rule_DatePart
    {
        private List<EnterRule> ParameterList = new List<EnterRule>();

        public Rule_Year(Rule_Context pContext, NonterminalToken pToken)
            : base(pContext, pToken, FunctionUtils.DateInterval.Year)
        {
            this.ParameterList = EnterRule.GetFunctionParameters(pContext, pToken);
        }

        /// <summary>
        /// Executes the reduction.
        /// </summary>
        /// <returns>Returns the date difference in years between two dates.</returns>
        public override object Execute()
        {
            object result = null;

            object p1 = this.ParameterList[0].Execute();

            if (p1 is DateTime)
            {

                DateTime param1 = (DateTime)p1;
                result = param1.Year;
            }
             

            return result;
        }

        public override void ToJavaScript(StringBuilder pJavaScriptBuilder)
        {
            object p1 = this.ParameterList[0].Execute();

            if (p1 is DateTime)
            {
                pJavaScriptBuilder.Append("CCE_Year(new Date(");
                pJavaScriptBuilder.Append(UnixTicks((DateTime)p1));
                pJavaScriptBuilder.Append("))");
            }

        }

        public static double UnixTicks(this DateTime dt)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = dt.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
            return Math.Round(ts.TotalMilliseconds, 0);
        }

    }
}
