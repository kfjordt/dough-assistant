<script setup lang="ts">
import { onMounted } from 'vue';
import { useRouter } from 'vue-router';
import { useUserStore } from '../stores/user';
import { ApiService } from '../api/ApiService';

const router = useRouter()
const userStore = useUserStore()

onMounted(() => {
    const userHasValidRememberMeCookie = false // Check if remember me cookie is valid in the backend
    if (userHasValidRememberMeCookie) {
        router.push("main")
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
