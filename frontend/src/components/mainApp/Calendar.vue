<template>
    <div class="calendar">
        <Week v-for="(week, index) in weeksInMonth" :week="week" :key="index" />
    </div>
</template>

<script setup lang="ts">
// import store from '../../store/store';
import { computed } from '@vue/reactivity';
import Week from './Week.vue';
import { useStore } from '../../store/store';

const weeksInMonth = useStore().currentCalendarState.getWeeksInSameMonth()

</script>

<style scoped>
.calendar {
    flex-grow: 1;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
}
</style>