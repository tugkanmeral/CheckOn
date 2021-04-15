import { ApiCaller } from "../services/ApiCaller";

export function CafeLogin(_email, _password) {
  var body = {
    Email: _email,
    Password: _password,
  };
  ApiCaller.Post("api/auth", body)
}

export function UserLogin(_email, _password) {
  var body = {
    Email: _email,
    Password: _password,
  };
  ApiCaller.Post("api/auth/login", body)
}

export function AdminLogin(_email, _password) {
  var body = {
    Email: _email,
    Password: _password,
  };
  ApiCaller.Post("api/auth/adminLogin", body)
}