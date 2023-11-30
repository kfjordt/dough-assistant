<script setup lang="ts">
import { onMounted } from 'vue';
import { useRouter } from 'vue-router';
import { useUserStore } from '../stores/user';
import { ApiService } from '../api/ApiService';

const router = useRouter()
const userStore = useUserStore()

onMounted(async () => {
    const userHasValidSessionCookie = await ApiService.isSessionCookieValid()
    if (userHasValidSessionCookie) {
        const userId = await ApiService.getLoggedInUserIdFromSessionCookie()
        userStore.setLoggedInUserId(userId)
        router.push("")
        return
    }

    const userHasValidRememberMeCookie = await ApiService.isRememberMeCookieValid()
    if (userHasValidRememberMeCookie) {
        const userId = await ApiService.getLoggedInUserIdFromRememberMeCookie()
        userStore.setLoggedInUserId(userId)
        router.push("")
        return
    }

    router.push("login")
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
