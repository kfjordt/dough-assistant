<template>
    <div class="main-view">
        <NavBar />
        <Calendar />
    </div>
</template>

<script setup lang="ts">
import NavBar from '../navBar/NavBar.vue';
import Calendar from '../calendar/Calendar.vue';

</script>

<style scoped>
.main-view {
    width: 100vw;
    height: 100vh;
    display: flex;
    flex-direction: column;
}
</style>