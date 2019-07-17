using Xunit;
using System.Collections.Generic;
using BoringHelpers.Collections;
using System;


namespace BoringHelpersTests.Collections
{
    public class KeyThrowingDictionary
    {
        [Theory]
        [InlineData("{6F9E54B5-6E93-44B3-8C0A-C2D0B86268A0}")]
        [InlineData("{4F7ECDAB-3BC9-49DF-8989-0B45C359455B}")]
        [InlineData("{241517B8-57B7-4242-9770-CFDB197B147A}")]
        public void Contains(string input)
        {
            KeyThrowingDictionary<string, bool> dict = new KeyThrowingDictionary<string, bool>();
            dict.Add(input, true);
            Assert.True(dict.ContainsKey(input));
        }

        [Theory]
        [InlineData("{6F9E54B5-6E93-44B3-8C0A-C2D0B86268A0}")]
        [InlineData("{4F7ECDAB-3BC9-49DF-8989-0B45C359455B}")]
        [InlineData("{241517B8-57B7-4242-9770-CFDB197B147A}")]
        public void Contains_Dictionary(string input)
        {
            Dictionary<string, bool> dict = new KeyThrowingDictionary<string, bool>();
            dict.Add(input, true);
            Assert.True(dict.ContainsKey(input));
        }

        [Theory]
        [InlineData("{6F9E54B5-6E93-44B3-8C0A-C2D0B86268A0}")]
        [InlineData("{4F7ECDAB-3BC9-49DF-8989-0B45C359455B}")]
        [InlineData("{241517B8-57B7-4242-9770-CFDB197B147A}")]
        public void Contains_IDictionary(string input)
        {
            IDictionary<string, bool> dict = new KeyThrowingDictionary<string, bool>();
            dict.Add(input, true);
            Assert.True(dict.ContainsKey(input));
        }

        [Theory]
        [InlineData("{6F9E54B5-6E93-44B3-8C0A-C2D0B86268A0}")]
        [InlineData("{4F7ECDAB-3BC9-49DF-8989-0B45C359455B}")]
        [InlineData("{241517B8-57B7-4242-9770-CFDB197B147A}")]
        public void SetIndexer(string input)
        {
            KeyThrowingDictionary<string, bool> dict = new KeyThrowingDictionary<string, bool>();
            dict[input] = default;
            Assert.True(dict.ContainsKey(input));
        }

        [Theory]
        [InlineData("{6F9E54B5-6E93-44B3-8C0A-C2D0B86268A0}")]
        [InlineData("{4F7ECDAB-3BC9-49DF-8989-0B45C359455B}")]
        [InlineData("{241517B8-57B7-4242-9770-CFDB197B147A}")]
        public void SetIndexer_Dictionary(string input)
        {
            Dictionary<string, bool> dict = new KeyThrowingDictionary<string, bool>();
            dict[input] = default;
            Assert.True(dict.ContainsKey(input));
        }

        [Theory]
        [InlineData("{6F9E54B5-6E93-44B3-8C0A-C2D0B86268A0}")]
        [InlineData("{4F7ECDAB-3BC9-49DF-8989-0B45C359455B}")]
        [InlineData("{241517B8-57B7-4242-9770-CFDB197B147A}")]
        public void SetIndexer_IDictionary(string input)
        {
            IDictionary<string, bool> dict = new KeyThrowingDictionary<string, bool>();
            dict[input] = default;
            Assert.True(dict.ContainsKey(input));
        }

        [Theory]
        [InlineData("{6F9E54B5-6E93-44B3-8C0A-C2D0B86268A0}")]
        [InlineData("{4F7ECDAB-3BC9-49DF-8989-0B45C359455B}")]
        [InlineData("{241517B8-57B7-4242-9770-CFDB197B147A}")]
        public void DoubleAdd(string input)
        {
            KeyThrowingDictionary<string, bool> dict = new KeyThrowingDictionary<string, bool>();
            dict.Add(input, true);
            Assert.Throws<ArgumentException>(() => dict.Add(input, true));
            try
            {
                dict.Add(input, true);
                Assert.True(false);
            }
            catch(ArgumentException ex)
            {
                Assert.Contains(input.ToString(), ex.Message);
                return;
            }
            Assert.True(false);
        }

        [Theory]
        [InlineData("{6F9E54B5-6E93-44B3-8C0A-C2D0B86268A0}")]
        [InlineData("{4F7ECDAB-3BC9-49DF-8989-0B45C359455B}")]
        [InlineData("{241517B8-57B7-4242-9770-CFDB197B147A}")]
        public void DoubleAdd_Dictionary(string input)
        {
            Dictionary<string, bool> dict = new KeyThrowingDictionary<string, bool>();
            dict.Add(input, true);
            Assert.Throws<ArgumentException>(() => dict.Add(input, true));
            try
            {
                dict.Add(input, true);
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.Contains(input.ToString(), ex.Message);
                return;
            }
            Assert.True(false);
        }

        [Theory]
        [InlineData("{6F9E54B5-6E93-44B3-8C0A-C2D0B86268A0}")]
        [InlineData("{4F7ECDAB-3BC9-49DF-8989-0B45C359455B}")]
        [InlineData("{241517B8-57B7-4242-9770-CFDB197B147A}")]
        public void DoubleAdd_IDictionary(string input)
        {
            IDictionary<string, bool> dict = new KeyThrowingDictionary<string, bool>();
            dict.Add(input, true);
            Assert.Throws<ArgumentException>(() => dict.Add(input, true));
            try
            {
                dict.Add(input, true);
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.Contains(input.ToString(), ex.Message);
                return;
            }
            Assert.True(false);
        }

        [Theory]
        [InlineData("{6F9E54B5-6E93-44B3-8C0A-C2D0B86268A0}")]
        [InlineData("{4F7ECDAB-3BC9-49DF-8989-0B45C359455B}")]
        [InlineData("{241517B8-57B7-4242-9770-CFDB197B147A}")]
        public void Missing(string input)
        {
            KeyThrowingDictionary<string, bool> dict = new KeyThrowingDictionary<string, bool>();
            Assert.Throws<KeyNotFoundException>(() => dict[input]);
            try
            {
                var discard = dict[input];
                Assert.True(false);
            }
            catch (KeyNotFoundException ex)
            {
                Assert.Contains(input.ToString(), ex.Message);
                return;
            }
            Assert.True(false);
        }

        [Theory]
        [InlineData("{6F9E54B5-6E93-44B3-8C0A-C2D0B86268A0}")]
        [InlineData("{4F7ECDAB-3BC9-49DF-8989-0B45C359455B}")]
        [InlineData("{241517B8-57B7-4242-9770-CFDB197B147A}")]
        public void Missing_Dictionary(string input)
        {
            Dictionary<string, bool> dict = new KeyThrowingDictionary<string, bool>();
            Assert.Throws<KeyNotFoundException>(() => dict[input]);
            try
            {
                var discard = dict[input];
                Assert.True(false);
            }
            catch (KeyNotFoundException ex)
            {
                Assert.Contains(input.ToString(), ex.Message);
                return;
            }
            Assert.True(false);
        }

        [Theory]
        [InlineData("{6F9E54B5-6E93-44B3-8C0A-C2D0B86268A0}")]
        [InlineData("{4F7ECDAB-3BC9-49DF-8989-0B45C359455B}")]
        [InlineData("{241517B8-57B7-4242-9770-CFDB197B147A}")]
        public void Missing_IDictionary(string input)
        {
            IDictionary<string, bool> dict = new KeyThrowingDictionary<string, bool>();
            Assert.Throws<KeyNotFoundException>(() => dict[input]);
            try
            {
                var discard = dict[input];
                Assert.True(false);
            }
            catch (KeyNotFoundException ex)
            {
                Assert.Contains(input.ToString(), ex.Message);
                return;
            }
            Assert.True(false);
        }
    }
}
