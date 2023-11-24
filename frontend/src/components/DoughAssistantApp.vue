<script setup lang="ts">
import {  onMounted } from 'vue';
import { useRouter } from 'vue-router';
import { useUserStore } from '../stores/user';

const router = useRouter()
const loggedInUserId = useUserStore().loggedInUserId

onMounted(() => {
    const isUserLoggedIn = loggedInUserId != null
    router.push(
        isUserLoggedIn
            ? "main"
            : "login"
    )
})

</script>

<template>
    <div class="app-container">
        <router-view></router-view>
    </div>
</template>

<style scoped>
.app-container {
    font-family: 'Segoe UI', 'Arial Narrow', Arial, sans-serif;
    background-color: rgb(30, 30, 30);
}
</style>
