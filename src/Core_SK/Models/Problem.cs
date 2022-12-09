/*
 * Ora esatta.
 *
 * #### Documentazione Il servizio Ora esatta ritorna l'ora del server in formato RFC5424 (syslog).  `2018-12-30T12:23:32Z`  ##### Sottosezioni E' possibile utilizzare - con criterio - delle sottosezioni.  #### Note  Il servizio non richiede autenticazione, ma va' usato rispettando gli header di throttling esposti in conformita' alle Linee Guida del Modello di interoperabilita'.  #### Informazioni tecniche ed esempi  Esempio:  ``` http http://localhost:8443/datetime/v1/echo {   'datetime': '2018-12-30T12:23:32Z' } ``` 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: filippo.derrigo@gmail.com
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace CoreSK.Models
{
    /// <summary>
    ///  This schema describes RFC7807 Problem Details for HTTP APIs.
    ///The specification is intentionally flexible, and allows to adapt
    ///the schema adding further properties, or not enforcing any of the properties
    ///below.
    ///
    ///To make this schema safe by default, additionalProperties are forbidden though.
    /// In case you need them, you can either re-define Problem or extend it
    ///using `allOf`.
    /// </summary>
    [DataContract]
    public partial class Problem : IEquatable<Problem>
    {
        /// <summary>
        /// A human readable explanation specific to this occurrence of the problem. You MUST NOT expose internal informations, personal data or implementation details through this field. 
        ///`
        /// detail` supports localized patterns whereas `title` pattern is only in ascii.
        /// </summary>
        /// <value>A human readable explanation specific to this occurrence of the problem. You MUST NOT expose internal informations, personal data or implementation details through this field. </value>
        /// <example>Request took too long to complete. </example>

        [DataMember(Name = "detail")]
        [MaxLength(4096)]
        [RegularExpression("^.{0,1024}$")]
        public string Detail { get; set; }

        /// <summary>
        /// An absolute URI that identifies the specific occurrence of the problem. It may or may not yield further information if dereferenced. 
        /// </summary>
        /// <value>An absolute URI that identifies the specific occurrence of the problem. It may or may not yield further information if dereferenced. </value>

        [MaxLength(2048)]
        [DataType(DataType.Url)]
        [DataMember(Name = "instance")]
        public string Instance { get; set; }

        /// <summary>
        /// The HTTP status code generated by the origin server for this occurrence of the problem. 
        /// </summary>
        /// <value>The HTTP status code generated by the origin server for this occurrence of the problem. </value>
        ///<example>503</example>
        [Range(100, 600)]
        [DataMember(Name = "status")]
        public int? Status { get; set; }

        /// <summary>
        /// A short, summary of the problem type. Written in english and readable for engineers (usually not suited for non technical stakeholders and not localized); example: Service Unavailable 
        /// </summary>
        /// <value>A short, summary of the problem type. Written in english and readable for engineers (usually not suited for non technical stakeholders and not localized); example: Service Unavailable </value>
        /// <example>Service Unavailable</example>


        [MaxLength(64)]
        [RegularExpression("^[ -~]{0,64}$")]

        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// An absolute URI that identifies the problem type.  When dereferenced, it SHOULD provide human-readable documentation for the problem type (e.g., using HTML). 
        /// </summary>
        /// <value>An absolute URI that identifies the problem type.  When dereferenced, it SHOULD provide human-readable documentation for the problem type (e.g., using HTML). </value>
        /// <example>https://tools.ietf.org/html/rfc7231#section-6.6.4</example>
        //default: about:blank
        [MaxLength(2048)]
        [DataType(DataType.Url)]
        [DefaultValue("about:blank")]
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Problem {\n");
            sb.Append("  Detail: ").Append(Detail).Append("\n");
            sb.Append("  Instance: ").Append(Instance).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Problem)obj);
        }

        /// <summary>
        /// Returns true if Problem instances are equal
        /// </summary>
        /// <param name="other">Instance of Problem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Problem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Detail == other.Detail ||
                    Detail != null &&
                    Detail.Equals(other.Detail)
                ) &&
                (
                    Instance == other.Instance ||
                    Instance != null &&
                    Instance.Equals(other.Instance)
                ) &&
                (
                    Status == other.Status ||
                    Status != null &&
                    Status.Equals(other.Status)
                ) &&
                (
                    Title == other.Title ||
                    Title != null &&
                    Title.Equals(other.Title)
                ) &&
                (
                    Type == other.Type ||
                    Type != null &&
                    Type.Equals(other.Type)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Detail != null)
                    hashCode = hashCode * 59 + Detail.GetHashCode();
                if (Instance != null)
                    hashCode = hashCode * 59 + Instance.GetHashCode();
                if (Status != null)
                    hashCode = hashCode * 59 + Status.GetHashCode();
                if (Title != null)
                    hashCode = hashCode * 59 + Title.GetHashCode();
                if (Type != null)
                    hashCode = hashCode * 59 + Type.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Problem left, Problem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Problem left, Problem right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
