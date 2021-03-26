import { ApiCaller } from "./ApiCaller";

export async function GetCafeList() {
  return ApiCaller.Get('api/cafes')
}
