<script lang="ts">
import { DateWrapper } from '../models/DateWrapper';

export default {
    computed: {
        weeksInCurrentMonth() {
            return DateWrapper.fromToday().getWeeksInSameMonth()
        }
    },
};
</script>

<template>
    <div class="main-view">
        <Week 
        v-for="(days, idx) in weeksInCurrentMonth" 
        :key="idx"
        :days="days" />
    </div>
</template>
 
<style scoped>
.main-view {
    background-color: var(--mainview-color-bg-primary);
    color: var(--mainview-color-text-primary);
    flex-grow: 1;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    user-select: none;
}
</style>