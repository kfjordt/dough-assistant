<template>
    <div>
        <button @click="login">Login Using Google</button>
        <!-- <div v-if="userDetails">
            <h2>User Details</h2>
            <p>Name: {{ userDetails.name }}</p>
            <p>Email: {{ userDetails.email }}</p>
            <p>Profile Picture: <img :src="userDetails.picture" alt="Profile Picture"></p>
        </div> -->
    </div>
</template>

<script setup lang="ts">
import { googleSdkLoaded } from "vue3-google-login";
import axios from "axios";
import { defineComponent } from "vue";

const login = () => {
    googleSdkLoaded(google => {
        google.accounts.oauth2.initCodeClient({
            client_id: "",
            scope: "email profile openid",
            redirect_uri: "http://localhost:4000/auth/callback",
            callback: response => {
                if (!response.code) {
                    return
                }
                
                console.log(response.code)
            }
        }).requestCode()
    });
}

</script>
