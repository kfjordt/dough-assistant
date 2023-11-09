export type UserInfo = {
    email: string
    name: string
}

export const parseGoogleResponseToUserInfo = (responseBody: any): UserInfo => {
    return {
        email: responseBody.email,
        name: responseBody.name,
    }
}