<script setup lang="ts">
import { googleSdkLoaded } from "vue3-google-login";
import { ref } from 'vue';
import { clientSecrets } from '../../ClientSecrets';
import { ApiService } from '../../api/ApiService';
import store from "../../store/store";
import { DateTime } from '../../models/common/DateTime';
import { setCookie } from 'typescript-cookie'
import { TokenValidator, TokenValidity, TokenState } from '../../models/common/TokenValidator';

const stayLoggedIn = ref(false);

const handleBearerToken = (bearerToken: string) => {
    const validator = new TokenValidator(bearerToken)

    validator.getState()
        .then(async (tokenState) => {
            if (tokenState.validity === TokenValidity.NotValid) {
                throw new Error("Token could not be verified by Google");
            }

            if (tokenState.validity === TokenValidity.ValidUserDoesNotExist) {
                await ApiService.postUser(tokenState.user.email, tokenState.user.name);
            }

            ApiService.getUserByEmail(tokenState.user.email)
                .then(user => store.actions.setCurrentlyLoggedInUser(user.email, bearerToken))
        })

    if (stayLoggedIn.value) {
        setCookie("BearerToken",
            bearerToken,
            {
                expires: DateTime.fromNow().addDays(30).getModel(),
                secure: true
            })
    }
}

const promptUserForGoogleLogin = async () => {
    googleSdkLoaded(google => {
        google.accounts.oauth2.initTokenClient({
            client_id: clientSecrets.googleClientId,
            scope: "email profile",

            callback: (response) => {
                const bearerToken = response.access_token;
                handleBearerToken(bearerToken)
            }
        }).requestAccessToken()
    });
}
</script>

<template>
    <div class="auth">
        <h1 class="auth-header">Dough Assistant</h1>
        <h2 class="auth-subheader">Blazingly brisk budgeting</h2>
        <button @click="promptUserForGoogleLogin" class="auth-button">Sign in with Google</button>
        <div>
            <input id="stay-logged-in" type="checkbox" v-model="stayLoggedIn">
            <label for="stay-logged-in">Keep me logged in for 30 days</label>
        </div>
    </div>
</template>

<style scoped>
.auth {
    margin: 20px;
    padding: 10px;
    border: 1px solid rgb(125, 125, 125);
    border-radius: 10px;
    user-select: none;
    display: flex;
    flex-direction: column;
    align-items: center;
}

.auth-header,
.auth-subheader {
    margin: 0;
    padding: 5px
}

.auth-subheader {
    font-weight: normal;
}

.auth-button {
    margin-top: 30px;
    cursor: pointer;
}
</style>