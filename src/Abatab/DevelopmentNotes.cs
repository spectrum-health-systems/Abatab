// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.DevelopmentNotes.cs
// Development notes for Abatab.
// b230807.1024
// -----------------------------------------------------------------------------

/* DEVNOTE
 * This class is used to test various development-related things, like how comments appear or whatever. There
 * isn't any actual logic here.
 */

namespace Abatab
{
    /// <summary>This method is for testing and examples.</summary>
    public static class DevelopmentNotes
    {
        /// <summary>Compares two numbers to determine if they are the same.</summary>
        /// <param name="numberOne">The first number.</param>
        /// <param name="numberTwo">The second number.</param>
        /// <remarks>
        ///     <para>
        ///         This method needs two things:
        ///         <list type="number">
        ///             <item>A number</item>
        ///             <item>Another number</item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         Numbers to be compared <u>must</u>:
        ///         <list type="bullet">
        ///             <item>
        ///                 Be &gt;= zero
        ///             </item>
        ///             <item>
        ///                 Be <i>less</i> than <c>100</c>
        ///             </item>
        ///             <item>
        ///                 Not be an <b>even</b> number
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         Keep in mind:
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Number</term>
        ///                 <description>Validity</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>1</term>
        ///                 <description>Valid.</description>
        ///             </item>
        ///             <item>
        ///                 <term>2</term>
        ///                 <description>Invalid</description>
        ///             </item>
        ///             <item>
        ///                 <term>200</term>
        ///                 <description>Invalid</description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         For more information please review the <see href="../link/GoesHere.html#Anchor">Abatab Documentation Project</see>.
        ///     </para>
        /// </remarks>
        /// <example>
        ///     Here is an example of the code:
        ///     <code>
        ///     if(numberOne == numberTwo)
        ///     {
        ///         return true;
        ///     }
        ///     else
        ///     {
        ///         return false;
        ///     }
        ///     </code>
        /// </example>
        /// <returns>A boolean of true or false.</returns>
        /// <value>Default value is <c>false</c></value>
        public static bool XmlDocumentationCommentExample(int numberOne, int numberTwo)
        {
            return true;
        }
    }
}