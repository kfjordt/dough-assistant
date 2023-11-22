<template>
    <div :style="{ backgroundColor: style.monthNavigatorPanel.background }" class="month-navigator">
        <CardButton @click="handleMonthClick(idx)" class="month-navigator-month-label" v-for="(month, idx) in months"
            :key="idx" :style="style.monthNavigatorButtons" :text="month" />
    </div>
</template>

<script setup lang="ts">
import CardButton from '../reusable/CardButton.vue';
import { useStyleStore } from '../../stores/style';
import { useCalendarStore } from '../../stores/calendar';

const style = useStyleStore().sectionStyles.navBar
const calendarStore = useCalendarStore()

const months = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
]

const emit = defineEmits(['monthClicked']);
const handleMonthClick = (monthIdx: number) => {
    calendarStore.setMonthIdx(monthIdx)
    emit('monthClicked');
}
</script>

<style scoped>
.month-navigator {
    margin-top: 4px;
    border-radius: 4px;
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    grid-auto-rows: 1fr;
    gap: 4px;
    padding: 4px;
}

.month-navigator-month-label {
    padding: 4px;
    font-size: small;
}
</style>