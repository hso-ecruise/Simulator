using System;
using System.Collections.Generic;
using System.Text;

namespace ecruise_Client
{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "10.6.6324.28497")]
    public partial class Client
    {
        private string _baseUrl = "https://api.ecruise.me/v1";

        public string access_token;

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

        /// <param name="email">eMail Address</param>
        /// <param name="password">Plain password</param>
        /// <returns>Authenficiation Token to use for further API calls</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Response> LoginAsync(string email, string password)
        {
            return LoginAsync(email, password, System.Threading.CancellationToken.None);
        }

        /// <param name="email">eMail Address</param>
        /// <param name="password">Plain password</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Authenficiation Token to use for further API calls</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Response> LoginAsync(string email, string password, System.Threading.CancellationToken cancellationToken)
        {
            if (email == null)
                throw new System.ArgumentNullException("email");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/public/login/{Email}");
            urlBuilder_.Replace("{Email}", System.Uri.EscapeDataString(email.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(password));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    //request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Response);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("There is no matching email<->password combination", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Response);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="email">eMail Address</param>
        /// <param name="token">Randomly generated token that has been sent to the user's
        ///   email address.</param>
        /// <returns>Activation was successful</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task ActivateAsync(string email, string token)
        {
            return ActivateAsync(email, token, System.Threading.CancellationToken.None);
        }

        /// <param name="email">eMail Address</param>
        /// <param name="token">Randomly generated token that has been sent to the user's
        ///   email address.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Activation was successful</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task ActivateAsync(string email, string token, System.Threading.CancellationToken cancellationToken)
        {
            if (email == null)
                throw new System.ArgumentNullException("email");

            if (token == null)
                throw new System.ArgumentNullException("token");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/public/activate/{Email}/{Token}");
            urlBuilder_.Replace("{Email}", System.Uri.EscapeDataString(email.ToString()));
            urlBuilder_.Replace("{Token}", System.Uri.EscapeDataString(token.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "204")
                        {
                            return;
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Email<->Token combination not found", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="registration">Data used to create the Customer.</param>
        /// <returns>The user has been created successfully.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> RegisterAsync(Registration registration)
        {
            return RegisterAsync(registration, System.Threading.CancellationToken.None);
        }

        /// <param name="registration">Data used to create the Customer.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The user has been created successfully.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> RegisterAsync(Registration registration, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/public/register");

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(registration));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "409")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The specified user already exists.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Returns a list of all `Customer` objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Customer>> CustomersAllAsync(string filter_properties)
        {
            return CustomersAllAsync(filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns a list of all `Customer` objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Customer>> CustomersAllAsync(string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/customers?");
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<Customer>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Customer>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The request is valid but there are no customers", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<Customer>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Returns a `Customer` object</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Customer> CustomersAsync(double customerId, string filter_properties)
        {
            return CustomersAsync(customerId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns a `Customer` object</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Customer> CustomersAsync(double customerId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (customerId == null)
                throw new System.ArgumentNullException("customerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/customers/{CustomerId}?");
            urlBuilder_.Replace("{CustomerId}", System.Uri.EscapeDataString(customerId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Customer);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Customer>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The specified customer does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Customer);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <returns>The password of the `Customer` object has been updated successfully.
        ///   Returns the reference to the updated `Customer` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> PasswordAsync(double customerId, string password)
        {
            return PasswordAsync(customerId, password, System.Threading.CancellationToken.None);
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The password of the `Customer` object has been updated successfully.
        ///   Returns the reference to the updated `Customer` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> PasswordAsync(double customerId, string password, System.Threading.CancellationToken cancellationToken)
        {
            if (customerId == null)
                throw new System.ArgumentNullException("customerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/customers/{CustomerId}/password");
            urlBuilder_.Replace("{CustomerId}", System.Uri.EscapeDataString(customerId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(password));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Specified `Customer` does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <returns>The email of the `Customer` object has been updated successfully.
        ///   Returns the reference to the updated `Customer` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> EmailAsync(double customerId, string email)
        {
            return EmailAsync(customerId, email, System.Threading.CancellationToken.None);
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The email of the `Customer` object has been updated successfully.
        ///   Returns the reference to the updated `Customer` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> EmailAsync(double customerId, string email, System.Threading.CancellationToken cancellationToken)
        {
            if (customerId == null)
                throw new System.ArgumentNullException("customerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/customers/{CustomerId}/email");
            urlBuilder_.Replace("{CustomerId}", System.Uri.EscapeDataString(customerId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(email));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Specified `Customer` does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "409")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("A `Customer` with the same email address already exists.", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <returns>The phone number of the `Customer` object has been updated
        ///   successfully.
        ///   Returns the reference to the updated `Customer` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> PhoneNumberAsync(double customerId, string phoneNumber)
        {
            return PhoneNumberAsync(customerId, phoneNumber, System.Threading.CancellationToken.None);
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The phone number of the `Customer` object has been updated
        ///   successfully.
        ///   Returns the reference to the updated `Customer` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> PhoneNumberAsync(double customerId, string phoneNumber, System.Threading.CancellationToken cancellationToken)
        {
            if (customerId == null)
                throw new System.ArgumentNullException("customerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/customers/{CustomerId}/phone-number");
            urlBuilder_.Replace("{CustomerId}", System.Uri.EscapeDataString(customerId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(phoneNumber));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Specified `Customer` does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <returns>The `ChipCardUid` of the `Customer` object has been updated
        ///   successfully.
        ///   Returns the reference to the updated `Customer` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> ChipcarduidAsync(double customerId, string chipCardUid)
        {
            return ChipcarduidAsync(customerId, chipCardUid, System.Threading.CancellationToken.None);
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The `ChipCardUid` of the `Customer` object has been updated
        ///   successfully.
        ///   Returns the reference to the updated `Customer` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> ChipcarduidAsync(double customerId, string chipCardUid, System.Threading.CancellationToken cancellationToken)
        {
            if (customerId == null)
                throw new System.ArgumentNullException("customerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/customers/{CustomerId}/chipcarduid");
            urlBuilder_.Replace("{CustomerId}", System.Uri.EscapeDataString(customerId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(chipCardUid));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Specified `Customer` does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <param name="address">Object with updated address information.
        ///   Empty fields remain unchanged.</param>
        /// <returns>The address of the `Customer` object has been updated
        ///   successfully.
        ///   Returns the reference to the updated `Customer` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> AddressAsync(double customerId, Address address)
        {
            return AddressAsync(customerId, address, System.Threading.CancellationToken.None);
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <param name="address">Object with updated address information.
        ///   Empty fields remain unchanged.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The address of the `Customer` object has been updated
        ///   successfully.
        ///   Returns the reference to the updated `Customer` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> AddressAsync(double customerId, Address address, System.Threading.CancellationToken cancellationToken)
        {
            if (customerId == null)
                throw new System.ArgumentNullException("customerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/customers/{CustomerId}/address");
            urlBuilder_.Replace("{CustomerId}", System.Uri.EscapeDataString(customerId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(address));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Specified `Customer` does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <returns>The `Verified` status of the `Customer` object has been updated
        ///   successfully.
        ///   Returns the reference to the updated `Customer` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> VerifiedAsync(double customerId, bool verified)
        {
            return VerifiedAsync(customerId, verified, System.Threading.CancellationToken.None);
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The `Verified` status of the `Customer` object has been updated
        ///   successfully.
        ///   Returns the reference to the updated `Customer` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> VerifiedAsync(double customerId, bool verified, System.Threading.CancellationToken cancellationToken)
        {
            if (customerId == null)
                throw new System.ArgumentNullException("customerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/customers/{CustomerId}/verified");
            urlBuilder_.Replace("{CustomerId}", System.Uri.EscapeDataString(customerId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(verified));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Specified `Customer` does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>Returns an array of `Customer` objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Customer>> ByLastnameAsync(string lastName)
        {
            return ByLastnameAsync(lastName, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns an array of `Customer` objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Customer>> ByLastnameAsync(string lastName, System.Threading.CancellationToken cancellationToken)
        {
            if (lastName == null)
                throw new System.ArgumentNullException("lastName");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/customers/by-lastname/{LastName}");
            urlBuilder_.Replace("{LastName}", System.Uri.EscapeDataString(lastName.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<Customer>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Customer>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("There are no customers with that last name.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<Customer>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>A list of all booking objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Booking>> BookingsAllAsync(string filter_properties)
        {
            return BookingsAllAsync(filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A list of all booking objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Booking>> BookingsAllAsync(string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/bookings?");
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<Booking>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Booking>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The request was valid but there are no booking objects", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<Booking>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="booking">The booking to create</param>
        /// <returns>The booking was created successfully. The response contains
        ///     a reference to the newly created object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> BookingsAsync(Booking booking)
        {
            return BookingsAsync(booking, System.Threading.CancellationToken.None);
        }

        /// <param name="booking">The booking to create</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The booking was created successfully. The response contains
        ///     a reference to the newly created object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> BookingsAsync(Booking booking, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/bookings");

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(booking));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "201")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Booking found. Returns the requested `Booking` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Booking> Bookings2Async(int bookingId, string filter_properties)
        {
            return Bookings2Async(bookingId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Booking found. Returns the requested `Booking` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Booking> Bookings2Async(int bookingId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (bookingId == null)
                throw new System.ArgumentNullException("bookingId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/bookings/{BookingId}?");
            urlBuilder_.Replace("{BookingId}", System.Uri.EscapeDataString(bookingId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Booking);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Booking>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Booking with requested booking id does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Booking);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Booking found. Returns the requested `Booking` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Booking> ByTripAsync(int tripId, string filter_properties)
        {
            return ByTripAsync(tripId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Booking found. Returns the requested `Booking` object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Booking> ByTripAsync(int tripId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (tripId == null)
                throw new System.ArgumentNullException("tripId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/bookings/by-trip/{TripId}?");
            urlBuilder_.Replace("{TripId}", System.Uri.EscapeDataString(tripId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Booking);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Booking>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Booking with requested booking id does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Booking);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Array of all bookings belonging to the customer</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Booking>> ByCustomerAllAsync(double customerId, string filter_properties)
        {
            return ByCustomerAllAsync(customerId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="customerId">Customer idenfitier number</param>
        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Array of all bookings belonging to the customer</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Booking>> ByCustomerAllAsync(double customerId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (customerId == null)
                throw new System.ArgumentNullException("customerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/bookings/by-customer/{CustomerId}?");
            urlBuilder_.Replace("{CustomerId}", System.Uri.EscapeDataString(customerId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<Booking>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Booking>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("No booking found that belongs to the customer", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Customer does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<Booking>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Array of all bookings planned for that day</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Booking>> ByPlannedDateAsync(string date, string filter_properties)
        {
            return ByPlannedDateAsync(date, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Array of all bookings planned for that day</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Booking>> ByPlannedDateAsync(string date, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (date == null)
                throw new System.ArgumentNullException("date");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/bookings/by-planned-date/{Date}?");
            urlBuilder_.Replace("{Date}", System.Uri.EscapeDataString(date.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<Booking>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Booking>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("There is no booking planned for the specified day", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<Booking>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Array of all bookings created at the specified day</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Booking>> ByBookedDateAsync(string date, string filter_properties)
        {
            return ByBookedDateAsync(date, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Array of all bookings created at the specified day</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Booking>> ByBookedDateAsync(string date, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (date == null)
                throw new System.ArgumentNullException("date");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/bookings/by-booked-date/{Date}?");
            urlBuilder_.Replace("{Date}", System.Uri.EscapeDataString(date.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<Booking>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Booking>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("There was no booking created at the specified day", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<Booking>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>A list of all trip objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Trip>> TripsAllAsync(Filterbystate? filterbystate, string filter_properties)
        {
            return TripsAllAsync(filterbystate, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A list of all trip objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Trip>> TripsAllAsync(Filterbystate? filterbystate, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/trips?");
            if (filterbystate != null) urlBuilder_.Append("filterbystate=").Append(System.Uri.EscapeDataString(filterbystate.Value.ToString())).Append("&");
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<Trip>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Trip>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The request was valid but there are no trip objects", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<Trip>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="trip">The trip to create</param>
        /// <returns>The trip was created successfully. The response contains
        ///     a reference to the newly created object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> TripsAsync(Trip trip)
        {
            return TripsAsync(trip, System.Threading.CancellationToken.None);
        }

        /// <param name="trip">The trip to create</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The trip was created successfully. The response contains
        ///     a reference to the newly created object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> TripsAsync(Trip trip, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/trips");

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(trip));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "201")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Requested trip</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Trip> Trips2Async(int tripId, string filter_properties)
        {
            return Trips2Async(tripId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Requested trip</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Trip> Trips2Async(int tripId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (tripId == null)
                throw new System.ArgumentNullException("tripId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/trips/{TripId}?");
            urlBuilder_.Replace("{TripId}", System.Uri.EscapeDataString(tripId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Trip);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Trip>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The requested trip does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Trip);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>The object has been updated successfully. The reference to the newly updated trip is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> Trips3Async(int tripId, Trip2 trip)
        {
            return Trips3Async(tripId, trip, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The object has been updated successfully. The reference to the newly updated trip is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> Trips3Async(int tripId, Trip2 trip, System.Threading.CancellationToken cancellationToken)
        {
            if (tripId == null)
                throw new System.ArgumentNullException("tripId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/trips/{TripId}");
            urlBuilder_.Replace("{TripId}", System.Uri.EscapeDataString(tripId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(trip));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("One of the given parameters is not valid", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The trip does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>A list of trip objects matching the given CarId</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Trip>> ByCarAllAsync(int carId, string filter_properties)
        {
            return ByCarAllAsync(carId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A list of trip objects matching the given CarId</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Trip>> ByCarAllAsync(int carId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (carId == null)
                throw new System.ArgumentNullException("carId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/trips/by-car/{CarId}?");
            urlBuilder_.Replace("{CarId}", System.Uri.EscapeDataString(carId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<Trip>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Trip>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The requested trip does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<Trip>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>Returns a list of all `Invoice` objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Invoice>> InvoicesAllAsync()
        {
            return InvoicesAllAsync(System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns a list of all `Invoice` objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Invoice>> InvoicesAllAsync(System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/invoices");

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<Invoice>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Invoice>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("There are no invoices.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<Invoice>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Requested invoice</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Invoice> InvoicesAsync(int invoiceId, string filter_properties)
        {
            return InvoicesAsync(invoiceId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Requested invoice</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Invoice> InvoicesAsync(int invoiceId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (invoiceId == null)
                throw new System.ArgumentNullException("invoiceId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/invoices/{InvoiceId}?");
            urlBuilder_.Replace("{InvoiceId}", System.Uri.EscapeDataString(invoiceId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Invoice);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Invoice>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The requested invoice does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Invoice);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>The object has been updated successfully. A reference to the newly updated invoice is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> PaidAsync(int invoiceId, bool paid)
        {
            return PaidAsync(invoiceId, paid, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The object has been updated successfully. A reference to the newly updated invoice is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> PaidAsync(int invoiceId, bool paid, System.Threading.CancellationToken cancellationToken)
        {
            if (invoiceId == null)
                throw new System.ArgumentNullException("invoiceId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/invoices/{InvoiceId}/paid");
            urlBuilder_.Replace("{InvoiceId}", System.Uri.EscapeDataString(invoiceId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(paid));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Invalid parameters", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The invoice does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>A list of invoice items</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<InvoiceItem>> ItemsAllAsync(int invoiceId, string filter_properties)
        {
            return ItemsAllAsync(invoiceId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A list of invoice items</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<InvoiceItem>> ItemsAllAsync(int invoiceId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (invoiceId == null)
                throw new System.ArgumentNullException("invoiceId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/invoices/{InvoiceId}/items?");
            urlBuilder_.Replace("{InvoiceId}", System.Uri.EscapeDataString(invoiceId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<InvoiceItem>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<InvoiceItem>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The invoice was found but there are no items on it.", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The requested invoice does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<InvoiceItem>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="invoiceItem">Invoice item to insert. InvoiceId has to match the invoice id in
        ///   the parameter.</param>
        /// <returns>The invoice item was created successfully. The response contains
        ///   a reference to the newly created object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> ItemsAsync(int invoiceId, InvoiceItem invoiceItem)
        {
            return ItemsAsync(invoiceId, invoiceItem, System.Threading.CancellationToken.None);
        }

        /// <param name="invoiceItem">Invoice item to insert. InvoiceId has to match the invoice id in
        ///   the parameter.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The invoice item was created successfully. The response contains
        ///   a reference to the newly created object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> ItemsAsync(int invoiceId, InvoiceItem invoiceItem, System.Threading.CancellationToken cancellationToken)
        {
            if (invoiceId == null)
                throw new System.ArgumentNullException("invoiceId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/invoices/{InvoiceId}/items");
            urlBuilder_.Replace("{InvoiceId}", System.Uri.EscapeDataString(invoiceId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(invoiceItem));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "201")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The requested invoice does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "409")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The invoice id in the header does not match the InvoiceId\n  property of the InvoiceItem object\n", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Returns the requested invoice item object</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<InvoiceItem> Items2Async(int invoiceItemId, string filter_properties)
        {
            return Items2Async(invoiceItemId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the requested invoice item object</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<InvoiceItem> Items2Async(int invoiceItemId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (invoiceItemId == null)
                throw new System.ArgumentNullException("invoiceItemId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/invoices/items/{InvoiceItemId}?");
            urlBuilder_.Replace("{InvoiceItemId}", System.Uri.EscapeDataString(invoiceItemId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(InvoiceItem);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<InvoiceItem>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The requested invoice or invoice item does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(InvoiceItem);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Returns an array of matching invoices</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Invoice>> ByCustomerAsync(int customerId, string filter_properties)
        {
            return ByCustomerAsync(customerId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns an array of matching invoices</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Invoice>> ByCustomerAsync(int customerId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (customerId == null)
                throw new System.ArgumentNullException("customerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/invoices/by-customer/{CustomerId}?");
            urlBuilder_.Replace("{CustomerId}", System.Uri.EscapeDataString(customerId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<Invoice>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Invoice>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The requested invoice or customer does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<Invoice>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Returns the invoice belonging to the invoice item</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Invoice> ByInvoiceItemAsync(int invoiceItemId, string filter_properties)
        {
            return ByInvoiceItemAsync(invoiceItemId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the invoice belonging to the invoice item</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Invoice> ByInvoiceItemAsync(int invoiceItemId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (invoiceItemId == null)
                throw new System.ArgumentNullException("invoiceItemId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/invoices/by-invoice-item/{InvoiceItemId}?");
            urlBuilder_.Replace("{InvoiceItemId}", System.Uri.EscapeDataString(invoiceItemId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Invoice);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Invoice>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The requested invoice item does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Invoice);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Returns a list of all maintenance objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Maintenance>> MaintenancesAllAsync(string filter_properties)
        {
            return MaintenancesAllAsync(filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns a list of all maintenance objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Maintenance>> MaintenancesAllAsync(string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/maintenances?");
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<Maintenance>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Maintenance>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The request was valid but there are no maintenances", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<Maintenance>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="maintenance">The maintenace to create</param>
        /// <returns>The maintenance was created successfully. The response contains
        ///   a reference to the newly created object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> MaintenancesAsync(Maintenance maintenance)
        {
            return MaintenancesAsync(maintenance, System.Threading.CancellationToken.None);
        }

        /// <param name="maintenance">The maintenace to create</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The maintenance was created successfully. The response contains
        ///   a reference to the newly created object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> MaintenancesAsync(Maintenance maintenance, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/maintenances");

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(maintenance));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "201")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="maintenanceId">Unique maintenance identified</param>
        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Returns the requested maintenance object</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Maintenance> Maintenances2Async(int maintenanceId, string filter_properties)
        {
            return Maintenances2Async(maintenanceId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="maintenanceId">Unique maintenance identified</param>
        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the requested maintenance object</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Maintenance> Maintenances2Async(int maintenanceId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (maintenanceId == null)
                throw new System.ArgumentNullException("maintenanceId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/maintenances/{MaintenanceId}?");
            urlBuilder_.Replace("{MaintenanceId}", System.Uri.EscapeDataString(maintenanceId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Maintenance);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Maintenance>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The maintenance with the requested id does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Maintenance);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Returns a list of car maintenance objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<CarMaintenance>> CarMaintenancesAllAsync(string filter_properties)
        {
            return CarMaintenancesAllAsync(filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns a list of car maintenance objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<CarMaintenance>> CarMaintenancesAllAsync(string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/car-maintenances?");
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<CarMaintenance>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<CarMaintenance>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("There are no car maintenances", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<CarMaintenance>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="carMaintenance">CarMaintenance object to be created.</param>
        /// <returns>The car maintenance was created successfully. The response contains
        ///   a reference to the newly created object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> CarMaintenancesAsync(CarMaintenance carMaintenance)
        {
            return CarMaintenancesAsync(carMaintenance, System.Threading.CancellationToken.None);
        }

        /// <param name="carMaintenance">CarMaintenance object to be created.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The car maintenance was created successfully. The response contains
        ///   a reference to the newly created object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> CarMaintenancesAsync(CarMaintenance carMaintenance, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/car-maintenances");

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(carMaintenance));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "201")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                            throw new SwaggerException<Error>("One of the fields supplied in the object is invalid. This may be\n  due to invalid ids.\n", status_, responseData_, headers_, result_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Returns the requested car maintenance object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<CarMaintenance> CarMaintenances2Async(int carMaintenanceId, string filter_properties)
        {
            return CarMaintenances2Async(carMaintenanceId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the requested car maintenance object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<CarMaintenance> CarMaintenances2Async(int carMaintenanceId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (carMaintenanceId == null)
                throw new System.ArgumentNullException("carMaintenanceId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/car-maintenances/{CarMaintenanceId}?");
            urlBuilder_.Replace("{CarMaintenanceId}", System.Uri.EscapeDataString(carMaintenanceId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(CarMaintenance);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<CarMaintenance>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Requested car maintenance does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(CarMaintenance);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>The specified car maintenance has been successfully updated.
        /// A reference to the updated car maintenence is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> CompletedDateAsync(int carMaintenanceId, System.DateTime completedDate)
        {
            return CompletedDateAsync(carMaintenanceId, completedDate, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The specified car maintenance has been successfully updated.
        /// A reference to the updated car maintenence is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> CompletedDateAsync(int carMaintenanceId, System.DateTime completedDate, System.Threading.CancellationToken cancellationToken)
        {
            if (carMaintenanceId == null)
                throw new System.ArgumentNullException("carMaintenanceId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/car-maintenances/{CarMaintenanceId}/completed-date");
            urlBuilder_.Replace("{CarMaintenanceId}", System.Uri.EscapeDataString(carMaintenanceId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(completedDate));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The date is in a invalid format.", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The specified car maintenance does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Returns the requested car maintenance object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<CarMaintenance> ByCarAsync(int carId, string filter_properties)
        {
            return ByCarAsync(carId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the requested car maintenance object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<CarMaintenance> ByCarAsync(int carId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (carId == null)
                throw new System.ArgumentNullException("carId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/car-maintenances/by-car/{CarId}?");
            urlBuilder_.Replace("{CarId}", System.Uri.EscapeDataString(carId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(CarMaintenance);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<CarMaintenance>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "203")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("There are no car maintenances that belong to this car.", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Requested car does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(CarMaintenance);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Returns the requested car maintenance object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<CarMaintenance> ByMaintenanceAsync(int maintenanceId, string filter_properties)
        {
            return ByMaintenanceAsync(maintenanceId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the requested car maintenance object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<CarMaintenance> ByMaintenanceAsync(int maintenanceId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (maintenanceId == null)
                throw new System.ArgumentNullException("maintenanceId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/car-maintenances/by-maintenance/{MaintenanceId}?");
            urlBuilder_.Replace("{MaintenanceId}", System.Uri.EscapeDataString(maintenanceId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(CarMaintenance);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<CarMaintenance>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "203")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("There are no car maintenances that belong to this maintenance.\n", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Requested maintenance does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(CarMaintenance);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Returns the requested car maintenance object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<CarMaintenance> ByInvoiceItem2Async(int invoiceItemId, string filter_properties)
        {
            return ByInvoiceItem2Async(invoiceItemId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the requested car maintenance object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<CarMaintenance> ByInvoiceItem2Async(int invoiceItemId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (invoiceItemId == null)
                throw new System.ArgumentNullException("invoiceItemId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/car-maintenances/by-invoice-item/{InvoiceItemId}?");
            urlBuilder_.Replace("{InvoiceItemId}", System.Uri.EscapeDataString(invoiceItemId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(CarMaintenance);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<CarMaintenance>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "203")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("There are no car maintenances that belong to this invoice item.\n", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Requested invoice item does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(CarMaintenance);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>A list of all car objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Car>> CarsAllAsync(string filter_properties)
        {
            return CarsAllAsync(filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A list of all car objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Car>> CarsAllAsync(string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/cars?");
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<Car>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Car>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The request was valid but there are no car objects", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<Car>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="car">The Car to create</param>
        /// <returns>The Car was created successfully. The response contains
        ///     a reference to the newly created object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> CarsAsync(Car car)
        {
            return CarsAsync(car, System.Threading.CancellationToken.None);
        }

        /// <param name="car">The Car to create</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The Car was created successfully. The response contains
        ///     a reference to the newly created object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> CarsAsync(Car car, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/cars");

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(car));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "201")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Requested car</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Car> Cars2Async(int carId, string filter_properties)
        {
            return Cars2Async(carId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Requested car</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Car> Cars2Async(int carId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (carId == null)
                throw new System.ArgumentNullException("carId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/cars/{CarId}?");
            urlBuilder_.Replace("{CarId}", System.Uri.EscapeDataString(carId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Car);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Car>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The requested car does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Car);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>The object has been updated successfully. The newly updated car is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Car> ChargingstateAsync(int carId, ChargingState chargingState)
        {
            return ChargingstateAsync(carId, chargingState, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The object has been updated successfully. The newly updated car is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Car> ChargingstateAsync(int carId, ChargingState chargingState, System.Threading.CancellationToken cancellationToken)
        {
            if (carId == null)
                throw new System.ArgumentNullException("carId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/cars/{CarId}/chargingstate");
            urlBuilder_.Replace("{CarId}", System.Uri.EscapeDataString(carId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(chargingState));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Car);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Car>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The given charging state was not valid", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The car does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Car);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>The object has been updated successfully. The newly updated car is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Car> BookingstateAsync(int carId, BookingState bookingState)
        {
            return BookingstateAsync(carId, bookingState, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The object has been updated successfully. The newly updated car is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Car> BookingstateAsync(int carId, BookingState bookingState, System.Threading.CancellationToken cancellationToken)
        {
            if (carId == null)
                throw new System.ArgumentNullException("carId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/cars/{CarId}/bookingstate");
            urlBuilder_.Replace("{CarId}", System.Uri.EscapeDataString(carId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(bookingState));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Car);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Car>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The given booking state is not valid", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The car does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Car);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>The object has been updated successfully. The newly updated car is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Car> MileageAsync(int carId, int mileage)
        {
            return MileageAsync(carId, mileage, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The object has been updated successfully. The newly updated car is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Car> MileageAsync(int carId, int mileage, System.Threading.CancellationToken cancellationToken)
        {
            if (carId == null)
                throw new System.ArgumentNullException("carId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/cars/{CarId}/mileage");
            urlBuilder_.Replace("{CarId}", System.Uri.EscapeDataString(carId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(mileage));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Car);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Car>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The given mileage is not valid", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The car does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Car);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>The object has been updated successfully. The newly updated car is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Car> ChargelevelAsync(int carId, double chargeLevel)
        {
            return ChargelevelAsync(carId, chargeLevel, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The object has been updated successfully. The newly updated car is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Car> ChargelevelAsync(int carId, double chargeLevel, System.Threading.CancellationToken cancellationToken)
        {
            if (carId == null)
                throw new System.ArgumentNullException("carId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/cars/{CarId}/chargelevel");
            urlBuilder_.Replace("{CarId}", System.Uri.EscapeDataString(carId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(chargeLevel));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Car);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Car>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The given charge level is not valid", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The car does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Car);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>The object has been updated successfully. The newly updated car is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Car> PositionAsync(int carId, double latitude, double longitude)
        {
            return PositionAsync(carId, latitude, longitude, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The object has been updated successfully. The newly updated car is returned.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Car> PositionAsync(int carId, double latitude, double longitude, System.Threading.CancellationToken cancellationToken)
        {
            if (carId == null)
                throw new System.ArgumentNullException("carId");

            if (latitude == null)
                throw new System.ArgumentNullException("latitude");

            if (longitude == null)
                throw new System.ArgumentNullException("longitude");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/cars/{CarId}/position/{Latitude}/{Longitude}");
            urlBuilder_.Replace("{CarId}", System.Uri.EscapeDataString(carId.ToString()));
            urlBuilder_.Replace("{Latitude}", System.Uri.EscapeDataString(latitude.ToString()));
            urlBuilder_.Replace("{Longitude}", System.Uri.EscapeDataString(longitude.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(string.Empty);
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Car);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Car>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The given latitude or longitude is not valid", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The car does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Car);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="radius">Radius of the area to search for cars.
        ///   If the radius is 0, only the closest one is returned.</param>
        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Closest car</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Car> ClosestToAsync(double latitude, double longitude, int? radius, string filter_properties)
        {
            return ClosestToAsync(latitude, longitude, radius, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="radius">Radius of the area to search for cars.
        ///   If the radius is 0, only the closest one is returned.</param>
        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Closest car</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Car> ClosestToAsync(double latitude, double longitude, int? radius, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (latitude == null)
                throw new System.ArgumentNullException("latitude");

            if (longitude == null)
                throw new System.ArgumentNullException("longitude");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/cars/closest-to/{Latitude}/{Longitude}?");
            urlBuilder_.Replace("{Latitude}", System.Uri.EscapeDataString(latitude.ToString()));
            urlBuilder_.Replace("{Longitude}", System.Uri.EscapeDataString(longitude.ToString()));
            if (radius != null) urlBuilder_.Append("radius=").Append(System.Uri.EscapeDataString(radius.Value.ToString())).Append("&");
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Car);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Car>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Car);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Returns an array of `CarChargingStation` objects.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<CarChargingStation>> CarChargingStationsAllAsync(string filter_properties)
        {
            return CarChargingStationsAllAsync(filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns an array of `CarChargingStation` objects.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<CarChargingStation>> CarChargingStationsAllAsync(string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/car-charging-stations?");
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<CarChargingStation>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<CarChargingStation>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The request was successful but there are no \n  CarChargingStation` objects\n", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<CarChargingStation>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>The `CarChargingStation` object was created successfully.
        /// Returns the reference to the newly created object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> CarChargingStationsAsync(CarChargingStation carChargingStation)
        {
            return CarChargingStationsAsync(carChargingStation, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The `CarChargingStation` object was created successfully.
        /// Returns the reference to the newly created object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> CarChargingStationsAsync(CarChargingStation carChargingStation, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/car-charging-stations");

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(carChargingStation));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "409")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("There is a conflict in the time span of the car.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>The `CarChargingStation` has been successfully updated.
        ///   Returns a reference to the updated object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> ChargeEndAsync(int carChargingStationId, System.DateTime chargeEnd)
        {
            return ChargeEndAsync(carChargingStationId, chargeEnd, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The `CarChargingStation` has been successfully updated.
        ///   Returns a reference to the updated object.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> ChargeEndAsync(int carChargingStationId, System.DateTime chargeEnd, System.Threading.CancellationToken cancellationToken)
        {
            if (carChargingStationId == null)
                throw new System.ArgumentNullException("carChargingStationId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/car-charging-stations/{CarChargingStationId}/charge-end");
            urlBuilder_.Replace("{CarChargingStationId}", System.Uri.EscapeDataString(carChargingStationId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(chargeEnd));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Invalid date format", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The requested `CarChargingStationId` does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>Returns a list of related `CarChargingStation` objects.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<CarChargingStation>> ByCar2Async(int carId)
        {
            return ByCar2Async(carId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns a list of related `CarChargingStation` objects.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<CarChargingStation>> ByCar2Async(int carId, System.Threading.CancellationToken cancellationToken)
        {
            if (carId == null)
                throw new System.ArgumentNullException("carId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/car-charging-stations/by-car/{CarId}");
            urlBuilder_.Replace("{CarId}", System.Uri.EscapeDataString(carId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<CarChargingStation>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<CarChargingStation>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("There are no car charging stations related to this car.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<CarChargingStation>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>Returns a list of related `CarChargingStation` objects.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<CarChargingStation>> ByChargingStationAsync(int chargingStationId)
        {
            return ByChargingStationAsync(chargingStationId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns a list of related `CarChargingStation` objects.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<CarChargingStation>> ByChargingStationAsync(int chargingStationId, System.Threading.CancellationToken cancellationToken)
        {
            if (chargingStationId == null)
                throw new System.ArgumentNullException("chargingStationId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/car-charging-stations/by-charging-station/{ChargingStationId}");
            urlBuilder_.Replace("{ChargingStationId}", System.Uri.EscapeDataString(chargingStationId.ToString()));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<CarChargingStation>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<CarChargingStation>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("There are no car charging stations related to this \n  charging station.\n", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<CarChargingStation>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Array of charging station objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ChargingStation>> ChargingStationsAllAsync(string filter_properties)
        {
            return ChargingStationsAllAsync(filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Array of charging station objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ChargingStation>> ChargingStationsAllAsync(string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/charging-stations?");
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<ChargingStation>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<ChargingStation>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<ChargingStation>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>Charging Station was successfully created.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PostReference> ChargingStationsAsync(ChargingStation chargingStation)
        {
            return ChargingStationsAsync(chargingStation, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Charging Station was successfully created.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PostReference> ChargingStationsAsync(ChargingStation chargingStation, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/charging-stations");

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(chargingStation));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "201")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "303")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(PostReference);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(responseData_);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                            throw new SwaggerException<PostReference>("The object already exists.", status_, responseData_, headers_, result_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("The object could not be created.", status_, responseData_, headers_, result_, null);
                        }

                        return default(PostReference);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Returns the requested charging station object</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ChargingStation> ChargingStations2Async(int chargingStationId, string filter_properties)
        {
            return ChargingStations2Async(chargingStationId, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the requested charging station object</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ChargingStation> ChargingStations2Async(int chargingStationId, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (chargingStationId == null)
                throw new System.ArgumentNullException("chargingStationId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/charging-stations/{ChargingStationId}?");
            urlBuilder_.Replace("{ChargingStationId}", System.Uri.EscapeDataString(chargingStationId.ToString()));
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ChargingStation);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ChargingStation>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The requested charging station object does not exist", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null);
                        }

                        return default(ChargingStation);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="radius">Radius in meters of the area to search for charging stations.
        /// If the radius is 0, only the closest one is returned.
        /// Defaults to 0.</param>
        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Closest charging station object</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ChargingStation>> ClosestToAllAsync(double latitude, double longitude, int? min_free_slots, int? radius, string filter_properties)
        {
            return ClosestToAllAsync(latitude, longitude, min_free_slots, radius, filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="radius">Radius in meters of the area to search for charging stations.
        /// If the radius is 0, only the closest one is returned.
        /// Defaults to 0.</param>
        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Closest charging station object</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ChargingStation>> ClosestToAllAsync(double latitude, double longitude, int? min_free_slots, int? radius, string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            if (latitude == null)
                throw new System.ArgumentNullException("latitude");

            if (longitude == null)
                throw new System.ArgumentNullException("longitude");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/charging-stations/closest-to/{Latitude}/{Longitude}?");
            urlBuilder_.Replace("{Latitude}", System.Uri.EscapeDataString(latitude.ToString()));
            urlBuilder_.Replace("{Longitude}", System.Uri.EscapeDataString(longitude.ToString()));
            if (min_free_slots != null) urlBuilder_.Append("min-free-slots=").Append(System.Uri.EscapeDataString(min_free_slots.Value.ToString())).Append("&");
            if (radius != null) urlBuilder_.Append("radius=").Append(System.Uri.EscapeDataString(radius.Value.ToString())).Append("&");
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<ChargingStation>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<ChargingStation>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<ChargingStation>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <returns>Array of statistic objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Statistic>> StatisticAllAsync(string filter_properties)
        {
            return StatisticAllAsync(filter_properties, System.Threading.CancellationToken.None);
        }

        /// <param name="filter_properties">Makes the server to return only the properties that match those in the 
        ///   query parameter.
        ///   This parameter is a comma seperated list of property names.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Array of statistic objects</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Statistic>> StatisticAllAsync(string filter_properties, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/statistic?");
            if (filter_properties != null) urlBuilder_.Append("filter-properties=").Append(System.Uri.EscapeDataString(filter_properties.ToString())).Append("&");
            urlBuilder_.Length--;

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(System.Collections.ObjectModel.ObservableCollection<Statistic>);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.ObjectModel.ObservableCollection<Statistic>>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(System.Collections.ObjectModel.ObservableCollection<Statistic>);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>Returns the requested charging station object</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Statistic> StatisticAsync(System.DateTime date)
        {
            return StatisticAsync(date, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the requested charging station object</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Statistic> StatisticAsync(System.DateTime date, System.Threading.CancellationToken cancellationToken)
        {
            if (date == null)
                throw new System.ArgumentNullException("date");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/statistic/{Date}");
            urlBuilder_.Replace("{Date}", System.Uri.EscapeDataString(date.ToString("s", System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    request_.Headers.Add("access_token", access_token);

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Statistic);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Statistic>(responseData_);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The date is in an invalid format.", status_, responseData_, headers_, null);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The specified statistic does not exist.", status_, responseData_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(Error);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseData_);

                            }
                            catch (System.Exception exception_)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }

                            throw new SwaggerException<Error>("Something went wrong", status_, responseData_, headers_, result_, null);
                        }

                        return default(Statistic);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

    }



    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class Booking
    {
        [Newtonsoft.Json.JsonProperty("bookingId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? BookingId { get; set; }

        /// <summary>See '#/definitions/Customer'</summary>
        [Newtonsoft.Json.JsonProperty("customerId", Required = Newtonsoft.Json.Required.Always)]
        public int CustomerId { get; set; }

        /// <summary>See '#/definitions/Trip'</summary>
        [Newtonsoft.Json.JsonProperty("tripId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? TripId { get; set; }

        /// <summary>See '#/definitions/InvoiceItem'</summary>
        [Newtonsoft.Json.JsonProperty("invoiceItemId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? InvoiceItemId { get; set; }

        [Newtonsoft.Json.JsonProperty("bookingPositionLatitude", Required = Newtonsoft.Json.Required.Always)]
        public double BookingPositionLatitude { get; set; }

        [Newtonsoft.Json.JsonProperty("bookingPositionLongitude", Required = Newtonsoft.Json.Required.Always)]
        public double BookingPositionLongitude { get; set; }

        [Newtonsoft.Json.JsonProperty("bookingDate", Required = Newtonsoft.Json.Required.Always)]
        public System.DateTime BookingDate { get; set; }

        [Newtonsoft.Json.JsonProperty("plannedDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime? PlannedDate { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Booking FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Booking>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class Car
    {
        [Newtonsoft.Json.JsonProperty("carId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CarId { get; set; }

        [Newtonsoft.Json.JsonProperty("licensePlate", Required = Newtonsoft.Json.Required.Always)]
        public string LicensePlate { get; set; }

        [Newtonsoft.Json.JsonProperty("chargingState", Required = Newtonsoft.Json.Required.Always)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CarChargingState ChargingState { get; set; }

        [Newtonsoft.Json.JsonProperty("bookingState", Required = Newtonsoft.Json.Required.Always)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CarBookingState BookingState { get; set; }

        /// <summary>The milage driven with this car in kilometers</summary>
        [Newtonsoft.Json.JsonProperty("mileage", Required = Newtonsoft.Json.Required.Always)]
        public int Mileage { get; set; }

        /// <summary>Current charging level of the car. From 0. to 100.</summary>
        [Newtonsoft.Json.JsonProperty("chargeLevel", Required = Newtonsoft.Json.Required.Always)]
        public double ChargeLevel { get; set; }

        /// <summary>The power of the motor in kilowatts</summary>
        [Newtonsoft.Json.JsonProperty("kilowatts", Required = Newtonsoft.Json.Required.Always)]
        public int Kilowatts { get; set; }

        [Newtonsoft.Json.JsonProperty("manufacturer", Required = Newtonsoft.Json.Required.Always)]
        public string Manufacturer { get; set; }

        [Newtonsoft.Json.JsonProperty("model", Required = Newtonsoft.Json.Required.Always)]
        public string Model { get; set; }

        [Newtonsoft.Json.JsonProperty("yearOfConstruction", Required = Newtonsoft.Json.Required.Always)]
        public int YearOfConstruction { get; set; }

        [Newtonsoft.Json.JsonProperty("lastKnownPositionLatitude", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? LastKnownPositionLatitude { get; set; }

        [Newtonsoft.Json.JsonProperty("lastKnownPositionLongitude", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? LastKnownPositionLongitude { get; set; }

        /// <summary>The Time at which the last</summary>
        [Newtonsoft.Json.JsonProperty("lastKnownPositionDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime? LastKnownPositionDate { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Car FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Car>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class CarChargingStation
    {
        [Newtonsoft.Json.JsonProperty("carChargingStationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CarChargingStationId { get; set; }

        /// <summary>See '#/definitions/Car'</summary>
        [Newtonsoft.Json.JsonProperty("carId", Required = Newtonsoft.Json.Required.Always)]
        public int CarId { get; set; }

        /// <summary>See '#/definitions/ChargingStation'</summary>
        [Newtonsoft.Json.JsonProperty("chargingStationId", Required = Newtonsoft.Json.Required.Always)]
        public int ChargingStationId { get; set; }

        [Newtonsoft.Json.JsonProperty("chargeStart", Required = Newtonsoft.Json.Required.Always)]
        public System.DateTime ChargeStart { get; set; }

        [Newtonsoft.Json.JsonProperty("chargeEnd", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime? ChargeEnd { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static CarChargingStation FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CarChargingStation>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class CarMaintenance
    {
        [Newtonsoft.Json.JsonProperty("carMaintenanceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CarMaintenanceId { get; set; }

        /// <summary>See '#/definitions/Car'</summary>
        [Newtonsoft.Json.JsonProperty("carId", Required = Newtonsoft.Json.Required.Always)]
        public int CarId { get; set; }

        /// <summary>See '#/definitions/Maintenance'</summary>
        [Newtonsoft.Json.JsonProperty("maintenanceId", Required = Newtonsoft.Json.Required.Always)]
        public int MaintenanceId { get; set; }

        /// <summary>See '#/definitions/InvoiceItem'</summary>
        [Newtonsoft.Json.JsonProperty("invoiceItemId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? InvoiceItemId { get; set; }

        [Newtonsoft.Json.JsonProperty("plannedDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime? PlannedDate { get; set; }

        [Newtonsoft.Json.JsonProperty("completedDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime? CompletedDate { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static CarMaintenance FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CarMaintenance>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class ChargingStation
    {
        [Newtonsoft.Json.JsonProperty("chargingStationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ChargingStationId { get; set; }

        /// <summary>Number of slots</summary>
        [Newtonsoft.Json.JsonProperty("slots", Required = Newtonsoft.Json.Required.Always)]
        public int Slots { get; set; }

        /// <summary>How many slots on the charging station are currently
        /// occupied by cars.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("slotsOccupied", Required = Newtonsoft.Json.Required.Always)]
        public int SlotsOccupied { get; set; }

        [Newtonsoft.Json.JsonProperty("latitude", Required = Newtonsoft.Json.Required.Always)]
        public double Latitude { get; set; }

        [Newtonsoft.Json.JsonProperty("longitude", Required = Newtonsoft.Json.Required.Always)]
        public double Longitude { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static ChargingStation FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ChargingStation>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class Configuration
    {
        [Newtonsoft.Json.JsonProperty("configurationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ConfigurationId { get; set; }

        /// <summary>Sets if new bookings of any customers are allowed or not
        /// </summary>
        [Newtonsoft.Json.JsonProperty("allowNewBookings", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? AllowNewBookings { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Configuration FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Configuration>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class Address
    {
        [Newtonsoft.Json.JsonProperty("country", Required = Newtonsoft.Json.Required.Always)]
        public string Country { get; set; }

        [Newtonsoft.Json.JsonProperty("city", Required = Newtonsoft.Json.Required.Always)]
        public string City { get; set; }

        [Newtonsoft.Json.JsonProperty("zipCode", Required = Newtonsoft.Json.Required.Always)]
        public int ZipCode { get; set; }

        [Newtonsoft.Json.JsonProperty("street", Required = Newtonsoft.Json.Required.Always)]
        public string Street { get; set; }

        [Newtonsoft.Json.JsonProperty("houseNumber", Required = Newtonsoft.Json.Required.Always)]
        public string HouseNumber { get; set; }

        /// <summary>Extra line for the user's address. Can contain various 
        ///   detail information about the user's address.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("addressExtraLine", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AddressExtraLine { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Address FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Address>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class Customer : Address
    {
        [Newtonsoft.Json.JsonProperty("customerId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CustomerId { get; set; }

        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Always)]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty("phoneNumber", Required = Newtonsoft.Json.Required.Always)]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("firstName", Required = Newtonsoft.Json.Required.Always)]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("lastName", Required = Newtonsoft.Json.Required.Always)]
        public string LastName { get; set; }

        /// <summary>The Unique ID of the chip card the customer gets
        /// to unlock a car.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("chipCardUid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ChipCardUid { get; set; }

        /// <summary>True if the user has activated his account by clicking on the
        ///   link in the activation email.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("activated", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Activated { get; set; }

        /// <summary>True if the user has verified his account at our head-quarter
        ///   by bringing us his driver's license.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("verified", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Verified { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Customer FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Customer>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class Error
    {
        /// <summary>Unique error code</summary>
        [Newtonsoft.Json.JsonProperty("code", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Code { get; set; }

        /// <summary>Basic error message</summary>
        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>Detailed error message</summary>
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Error FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class Invoice
    {
        [Newtonsoft.Json.JsonProperty("invoiceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? InvoiceId { get; set; }

        /// <summary>See '#/definitions/Customer'</summary>
        [Newtonsoft.Json.JsonProperty("customerId", Required = Newtonsoft.Json.Required.Always)]
        public int CustomerId { get; set; }

        [Newtonsoft.Json.JsonProperty("totalAmount", Required = Newtonsoft.Json.Required.Always)]
        public double TotalAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("paid", Required = Newtonsoft.Json.Required.Always)]
        public bool Paid { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Invoice FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Invoice>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class InvoiceItem
    {
        [Newtonsoft.Json.JsonProperty("invoiceItemId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? InvoiceItemId { get; set; }

        /// <summary>See '#/definitions/Invoice'</summary>
        [Newtonsoft.Json.JsonProperty("invoiceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? InvoiceId { get; set; }

        /// <summary>Text which will appear on the invoice.
        /// Can contain the name of the service or some other reason.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("reason", Required = Newtonsoft.Json.Required.Always)]
        public string Reason { get; set; }

        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public InvoiceItemType Type { get; set; } = InvoiceItemType.DEBIT;

        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        public double Amount { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static InvoiceItem FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<InvoiceItem>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class Maintenance
    {
        [Newtonsoft.Json.JsonProperty("maintenenaceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MaintenenaceId { get; set; }

        [Newtonsoft.Json.JsonProperty("spontaneously", Required = Newtonsoft.Json.Required.Always)]
        public bool Spontaneously { get; set; }

        [Newtonsoft.Json.JsonProperty("atMileage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? AtMileage { get; set; }

        [Newtonsoft.Json.JsonProperty("atDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime? AtDate { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Maintenance FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Maintenance>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class PostReference
    {
        /// <summary>The ressource's unique identifier
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Id { get; set; }

        /// <summary>URL to the ressource
        /// </summary>
        [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Url { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PostReference FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PostReference>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class Trip
    {
        [Newtonsoft.Json.JsonProperty("tripId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? TripId { get; set; }

        /// <summary>See '#/definitions/Car'</summary>
        [Newtonsoft.Json.JsonProperty("carId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CarId { get; set; }

        /// <summary>See '#/definitions/Customer'</summary>
        [Newtonsoft.Json.JsonProperty("customerId", Required = Newtonsoft.Json.Required.Always)]
        public int CustomerId { get; set; }

        /// <summary>Date and time when the trip started</summary>
        [Newtonsoft.Json.JsonProperty("startDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime? StartDate { get; set; }

        /// <summary>Date and time when the trip ended</summary>
        [Newtonsoft.Json.JsonProperty("endDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime? EndDate { get; set; }

        [Newtonsoft.Json.JsonProperty("startChargingStationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? StartChargingStationId { get; set; }

        [Newtonsoft.Json.JsonProperty("endChargingStationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? EndChargingStationId { get; set; }

        /// <summary>The distance travelled with this trip in kilometers</summary>
        [Newtonsoft.Json.JsonProperty("distanceTravelled", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? DistanceTravelled { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Trip FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Trip>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class Statistic
    {
        /// <summary>The day the statistic is for (Set to 12:00 AM)</summary>
        [Newtonsoft.Json.JsonProperty("date", Required = Newtonsoft.Json.Required.Always)]
        public System.DateTime Date { get; set; }

        /// <summary>The known number of bookings at this day at midnight</summary>
        [Newtonsoft.Json.JsonProperty("bookings", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Bookings { get; set; }

        /// <summary>The overall charge level of all cars at midnight</summary>
        [Newtonsoft.Json.JsonProperty("averageChargeLevel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AverageChargeLevel { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Statistic FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Statistic>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class Registration : Address
    {
        [Newtonsoft.Json.JsonProperty("Email", Required = Newtonsoft.Json.Required.Always)]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty("Password", Required = Newtonsoft.Json.Required.Always)]
        public string Password { get; set; }

        [Newtonsoft.Json.JsonProperty("FirstName", Required = Newtonsoft.Json.Required.Always)]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("LastName", Required = Newtonsoft.Json.Required.Always)]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty("PhoneNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Registration FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Registration>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public enum Filterbystate
    {
        [System.Runtime.Serialization.EnumMember(Value = "FINISHED")]
        FINISHED = 0,

        [System.Runtime.Serialization.EnumMember(Value = "NOTFINISHED")]
        NOTFINISHED = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class Trip2
    {
        [Newtonsoft.Json.JsonProperty("DistanceTravelled", Required = Newtonsoft.Json.Required.Always)]
        public double DistanceTravelled { get; set; }

        [Newtonsoft.Json.JsonProperty("EndChargingStationId", Required = Newtonsoft.Json.Required.Always)]
        public int EndChargingStationId { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Trip2 FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Trip2>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public enum ChargingState
    {
        [System.Runtime.Serialization.EnumMember(Value = "DISCHARGING")]
        DISCHARGING = 0,

        [System.Runtime.Serialization.EnumMember(Value = "CHARGING")]
        CHARGING = 1,

        [System.Runtime.Serialization.EnumMember(Value = "FULL")]
        FULL = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public enum BookingState
    {
        [System.Runtime.Serialization.EnumMember(Value = "AVAILABLE")]
        AVAILABLE = 0,

        [System.Runtime.Serialization.EnumMember(Value = "BOOKED")]
        BOOKED = 1,

        [System.Runtime.Serialization.EnumMember(Value = "BLOCKED")]
        BLOCKED = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public partial class Response
    {
        /// <summary>The users id
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Id { get; set; }

        /// <summary>Token (SHA256 hash)</summary>
        [Newtonsoft.Json.JsonProperty("Token", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Token { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Response FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public enum CarChargingState
    {
        [System.Runtime.Serialization.EnumMember(Value = "DISCHARGING")]
        DISCHARGING = 0,

        [System.Runtime.Serialization.EnumMember(Value = "CHARGING")]
        CHARGING = 1,

        [System.Runtime.Serialization.EnumMember(Value = "FULL")]
        FULL = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public enum CarBookingState
    {
        [System.Runtime.Serialization.EnumMember(Value = "AVAILABLE")]
        AVAILABLE = 0,

        [System.Runtime.Serialization.EnumMember(Value = "BOOKED")]
        BOOKED = 1,

        [System.Runtime.Serialization.EnumMember(Value = "BLOCKED")]
        BLOCKED = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.33.6323.36213")]
    public enum InvoiceItemType
    {
        [System.Runtime.Serialization.EnumMember(Value = "DEBIT")]
        DEBIT = 0,

        [System.Runtime.Serialization.EnumMember(Value = "CREDIT")]
        CREDIT = 1,

    }



    [System.CodeDom.Compiler.GeneratedCode("NSwag", "10.6.6324.28497")]
    public class SwaggerException : System.Exception
    {
        public string StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public SwaggerException(string message, string statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "10.6.6324.28497")]
    public class SwaggerException<TResult> : SwaggerException
    {
        public TResult Result { get; private set; }

        public SwaggerException(string message, string statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    
    }
}
