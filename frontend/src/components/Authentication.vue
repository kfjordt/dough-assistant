<template>
    <div>
        <button @click="loginWithGoogle">Login Using Google</button>
    </div>
</template>


<script setup lang="ts">
import { googleSdkLoaded } from "vue3-google-login";
import { defineComponent } from "vue";
import { clientSecrets } from '../clientSecrets';

const loginWithGoogle = () => {
    googleSdkLoaded(google => {
        google.accounts.oauth2.initTokenClient({
            client_id: clientSecrets.googleClientId,
            scope: "email profile",
            callback: (response) => {
                fetchUserInfo(response.access_token)
            }
        }).requestAccessToken()

    });
}

const fetchUserInfo = (accessToken: string) => {
    // Define the Google API endpoint for user info
    const userInfoEndpoint = 'https://www.googleapis.com/oauth2/v2/userinfo';

    // Make a GET request to the user info endpoint
    fetch(userInfoEndpoint, {
        headers: {
            'Authorization': `Bearer ${accessToken}`
        }
    })
        .then(response => response.json())
        .then(data => {
            // Here, 'data' will contain the user's email and profile information
            console.log('User Info:', data);
        })
        .catch(error => {
            console.error('Failed to fetch user info:', error);
        });
}
</script>