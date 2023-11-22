<template>
    <div class="year-navigator" :style="{ backgroundColor: style.monthNavigatorPanel.background }">
        <div class="year-navigator-slider-buttons">
            <IconButton @click="decrementYearCollection()" :icon="Icons.LeftArrow" :style="style.monthNavigatorButtons" />
            <IconButton @click="incrementYearCollection()" :icon="Icons.RightArrow" :style="style.monthNavigatorButtons" />
        </div>
        <div class="year-collection">
            <CardButton @click="handleYearClick(years[idx])" class="year-navigator-year-label" v-for="(year, idx) in years"
                :key="idx" :style="style.monthNavigatorButtons" :text="year.toString()" />
        </div>
    </div>
</template>

<script setup lang="ts">
import CardButton from '../reusable/CardButton.vue';
import { useStyleStore } from '../../stores/style';
import { useCalendarStore } from '../../stores/calendar';
import { computed, ref } from 'vue';
import IconButton from '../reusable/IconButton.vue';
import { Icons } from '../../models/icons/Icons';

const style = useStyleStore().sectionStyles.navBar

const calendarStore = useCalendarStore()
const years = ref(calendarStore.ongoingYearCollection)

const decrementYearCollection = () => {
    years.value = years.value.map(year => year - 16);
}

const incrementYearCollection = () => {
    years.value = years.value.map(year => year + 16);
}

const emit = defineEmits(['yearClicked']);
const handleYearClick = (year: number) => {
    calendarStore.setYear(year)

    emit('yearClicked');
}
</script>

<style scoped>
.year-navigator {
    border-radius: 4px;
    padding: 4px;
    margin-top: 4px;
}

.year-collection {
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    grid-auto-rows: 1fr;
    gap: 4px;
}
.year-navigator-year-label {
    padding: 4px;
    font-size: small;
}

.year-navigator-slider-buttons {
    display: flex;
    justify-content: center;
}
</style>