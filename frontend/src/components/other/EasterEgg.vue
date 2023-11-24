<template>
    <div @click="handleClick()" class="easter-egg-container">
        <img src="@/assets/brainstorming.png" alt="Easter egg" />
    </div>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router'

const router = useRouter()

const handleClick = () => {
    router.push("login")
}
</script>

<style scoped>
.easter-egg-container {
    height: 100vh;
    display: flex;
    justify-content: center;
    align-items: center;
}
</style>