<script setup lang="ts">
import { DateTime } from '../../models/common/DateTime';
import Calendar from './Calendar.vue';
import NavBar from './NavBar.vue';

</script>

<template>
    <div class="main-view">
        <NavBar />
        <Calendar />
    </div>
</template>
 

<style scoped>
.main-view {
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
    user-select: none;
}
</style>