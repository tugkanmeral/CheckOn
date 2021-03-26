export class ApiCaller {
  static Post = async (url, bodyObj, user) => {
    var headers = null;
    if (user && user.token)
      headers = {
        "Content-Type": "application/json",
        Authorization: "Bearer " + user.token,
      };
    else
      headers = {
        "Content-Type": "application/json",
      };

    return await fetch(url, {
      method: "POST",
      headers: headers,
      body: JSON.stringify(bodyObj),
    })
      .then((response) => {
        if (response.status === 500) {
          return { success: false, errorMessage: "Serverda hata oluştu! " };
        }
        return response.json();
      })
      .then((data) => data)
      .catch((e) => alert(e));
  };

  static Get = async (url, user) => {
    var body = null;
    if (user && user.token)
      body = {
        method: "GET",
        headers: {
          Authorization: "Bearer " + user.token,
        },
      };
    else
      body = {
        method: "GET",
      };

    return await fetch(url, body)
      .then((response) => {
        if (!response.ok) {
          return { success: false, errorMessage: response.statusText };
        }
        return response.json();
      })
      .then((data) => data);
  };
}
