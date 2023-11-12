export class UserState {
    isLoggedIn: boolean
    email?: string
    bearerToken?: string

    constructor(isLoggedIn: boolean, id?: string, bearerToken?: string) {
        this.isLoggedIn = isLoggedIn,
        this.email = id;
        this.bearerToken = bearerToken
    }
}